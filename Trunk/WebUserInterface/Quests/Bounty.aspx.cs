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
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Quests;

namespace OrionsBelt.WebUserInterface.Quests
{
    public class BountyPage : System.Web.UI.Page {

        #region Fields

        protected Literal info;
        protected Button accept;
        protected Button abandon;
        protected PlaceHolder completingQuest;
        protected PlaceHolder questCompleted;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            QuestStorage storage = EntityUtils.GetFromQueryString<QuestStorage>("Id");
            State.SetItems<IQuestData>(QuestConversion.ConvertStorageToQuest(storage));

            accept.Text = LanguageManager.Instance.Get("Accept");
            accept.Click += new EventHandler(accept_Click);

            abandon.Text = LanguageManager.Instance.Get("AbandonQuest");
            abandon.Click += new EventHandler(abandon_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IQuestData data = State.GetItems<IQuestData>();
            info.Text = string.Format("{0}<br/>{1}", GetTitle(data), GetObjective(data));
            accept.Enabled = accept.Visible = GetAcceptState();
            abandon.Enabled = abandon.Visible = GetAbandonState();
            questCompleted.Visible = data.Completed;
            completingQuest.Visible = data.Percentage >= 100 && !data.Completed;
        }

        private bool GetAbandonState()
        {
			foreach (IQuestData data in BountyParticipantsRender.GetQuestList()) {
                if (data.Storage.Player.Id == PlayerUtils.Current.Id && data.QuestIntProgress["Points"] == 0) {
                    return true;
                }
            }

            return false;
        }

        private bool GetAcceptState()
        {
            IQuestData template = State.GetItems<IQuestData>();

            if (template.QuestIntConfig["TargetId"] == PlayerUtils.Current.Id ||
                template.QuestIntConfig["SourceId"] == PlayerUtils.Current.Id ||
                template.Completed || template.Percentage >= 100) {
                return false;
            }


			foreach (IQuestData data in BountyParticipantsRender.GetQuestList()) {
                if (data.Storage.Player.Id == PlayerUtils.Current.Id) {
                    return false;
                }
            }

            return true;
        }

        public static string GetTitle(IQuestData data)
        {
            return string.Format(LanguageManager.Instance.Get("CustomBountyInfo"),
                    GetSourceLink(data),
                    GetOrions(data),
                    GetTargetLink(data)
                );
        }

        private string GetObjective(IQuestData data)
        {
            return string.Format(LanguageManager.Instance.Get("CustomBountyObjective"), data.QuestIntConfig["Points"]);
        }

        void accept_Click(object sender, EventArgs e)
        {
            if( GetAcceptState() ) {
                IQuestData data = State.GetItems<IQuestData>();
                IQuestData newData = QuestManager.AcceptCustomBounty(PlayerUtils.Current, data);
				BountyParticipantsRender.GetQuestList().Add(newData);
                accept.Visible = false;
            }
        }

        void abandon_Click(object sender, EventArgs e)
        {
            QuestManager.AbandonCustomBounty(PlayerUtils.Current, State.GetItems<IQuestData>());
            Response.Redirect("~/Quests/Default.aspx");
        }

        #endregion Events

        #region Utils

        private static string GetOrions(IQuestData data)
        {
            return data.QuestIntConfig["Reward"].ToString();
        }

        private static object GetTargetLink(IQuestData data)
        {
            return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                    WebUtilities.ApplicationPath, data.QuestIntConfig["TargetId"], data.QuestStringConfig["TargetName"]
                );
        }

        private static string GetSourceLink(IQuestData data)
        {
            return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                    WebUtilities.ApplicationPath, data.QuestIntConfig["SourceId"], data.QuestStringConfig["SourceName"]
                );
        }

        #endregion Utils

    };
}
