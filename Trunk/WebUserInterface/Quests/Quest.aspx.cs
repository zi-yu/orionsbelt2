using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.Quests;
using System.IO;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Quests
{
    public class Quest : System.Web.UI.Page  {

        #region Fields

        protected Literal questDescription;
        protected Literal questRewards;
        protected Literal resultPanel;
        protected Button submitButton;
        protected Button cancelButton;
        protected PlaceHolder content;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            submitButton.Click += new EventHandler(submitButton_Click);
            cancelButton.Click += new EventHandler(cancelButton_Click);
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            IQuestData data = GetData();
            data.Info.OnAbandon(data);
            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                persistance.Delete(data.Storage);
                persistance.Flush();
            }
            Response.Redirect("Default.aspx");
        }

        void submitButton_Click(object sender, EventArgs e)
        {
            IQuestInfo info = GetQuestInfo();
            if (ToAccept(info)) {
                AcceptQuest();
            } else {
                DeliverQuest();
            }
        }

        private bool ToAccept(IQuestInfo info)
        {
            return info.IsProgressive && string.IsNullOrEmpty(Request.QueryString["Id"]);
        }

        private bool MayCancel(IQuestInfo info)
        {
            return info.IsProgressive && !string.IsNullOrEmpty(Request.QueryString["Id"]);
        }

        private void AcceptQuest()
        {
            IQuestInfo info = GetQuestInfo();
            if (!AvailableQuestList.CanIncludeQuestInfo(PlayerUtils.Current.Quests, info)) {
                throw new UnAuthorizedException();
            }
            IQuestData data = info.AddToPlayer(PlayerUtils.Current);
            info.PrepareDataFromArgs(data, Request.QueryString);
            GameEngine.Persist(PlayerUtils.Current);
            content.Visible = false;
            Response.Redirect("Default.aspx");
        }

        private void DeliverQuest()
        {
            IQuestInfo info = GetQuestInfo();

            IQuestData data = GetData();

            Result result = info.CanComplete(data);
            SetResult(result);
            if (result.Ok){
                info.Complete(data);
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.Update(Utils.Principal);
                GameEngine.Persist(PlayerUtils.Current);
            }

            content.Visible = !result.Ok;

            if( result.Ok ) {
                Response.Redirect("Default.aspx");
            }
        }

        private void SetResult(Result result)
        {
            string css = "success";
            string token = "GenericSuccess";
            if (!result.Ok) {
                css = "information";
                token = "GenericFail";
            }
            resultPanel.Text = string.Format("<div class='{0}'>{1}</div>", css, LanguageManager.Instance.Get(token));
        }

        private IQuestData GetData()
        {
            string raw = Request.QueryString["Id"];
            if (string.IsNullOrEmpty(raw)) {
                QuestData data = new QuestData();
                data.Player = PlayerUtils.Current;
                return data;
            }

            int id = int.Parse(raw);
            IList<QuestStorage> list = Hql.Query<QuestStorage>("select quest from SpecializedQuestStorage quest where quest.Id = :id", Hql.Param("id", id));
            IQuestData dbData = QuestConversion.ConvertStorageToQuest(list[0]);
            dbData.Player = PlayerUtils.Current;
            IList<IQuestData> quests = new List<IQuestData>();
            quests.Add(dbData);
            dbData.Player.Quests = quests;
            return dbData;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IPlayer player = PlayerUtils.Current;
            IQuestInfo info = GetQuestInfo();
            if (!info.IsAvailable(player)) {
                throw new UIException("Quest not available for player");
            }
            PrepareControls(player, info);
        }

        #endregion Events

        #region Utils

        private IQuestInfo GetQuestInfo()
        {
            string qs = HttpContext.Current.Request.QueryString["Info"];
            if (string.IsNullOrEmpty(qs)) {
                throw new UIException("No Info at query string");
            }
            return QuestManager.GetQuestType(qs);
        }

        private void PrepareControls(IPlayer player, IQuestInfo info)
        {
            questDescription.Text = LanguageManager.Instance.Get(info.Name);

            TextWriter writer = new StringWriter();
            AvailableQuestList.WriteRewards(writer, info, true);
            questRewards.Text = writer.ToString();

            cancelButton.Text = LanguageManager.Instance.Get("AbandonQuest");
            cancelButton.Visible = false;
            cancelButton.Enabled = false;

            if ( ToAccept(info)) {
                submitButton.Text = LanguageManager.Instance.Get("Accept");
            } else {
                submitButton.Text = LanguageManager.Instance.Get("Deliver");
            }

            if (MayCancel(info))  {
                cancelButton.Visible = true;
                cancelButton.Enabled = true;
            }

        }

        #endregion Utils

    };
}
