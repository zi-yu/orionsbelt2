using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PlayerProfileActions : Control {

        #region Fields

		//private string token;
        //private string css;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WebUtilities.ProcessPostBackAction(this.Page, ProcessAdd, "AddFriendOrFoe");
            if (!Utils.Principal.IsInRole("user")) {
                Visible = false;
            }
            IPlayer target = State.GetItems<IPlayer>();
            if (Utils.PrincipalExists && target.Principal.Id == Utils.Principal.Id) {
                Visible = false;
            }
        }

        public void ProcessAdd(string type, string action, string data)
        {
            IPlayer target = State.GetItems<IPlayer>();
            if (action == "Friend") {
                FriendOrFoeManager.AddFriend(PlayerUtils.Current, target);
                SuccessBoard.AddMessage(string.Format(LanguageManager.Instance.Get("AddedFriend"), target.Name));
            } else if (action == "Foe") {
                FriendOrFoeManager.AddEnemy(PlayerUtils.Current, target);
                SuccessBoard.AddMessage(string.Format(LanguageManager.Instance.Get("AddedFoe"), target.Name));
            } else if (action == "Remove") {
                FriendOrFoeManager.RemoveRelationship(PlayerUtils.Current, target, int.Parse(data));
            }
        }

        protected override void Render(HtmlTextWriter mainwriter)
        {
            StringWriter writer = new StringWriter();

            IPlayer player = State.GetItems<IPlayer>();

            writer.Write("<dl class='profileActions'>");

            FriendOrFoe relation = GetRelation(player);

            if (relation == null) {
                writer.Write("<dd>");
                GenericRenderer.WriteRightLinkButton(writer, WebUtilities.GetActionJs("AddFriendOrFoe", "Friend", string.Empty, true), LanguageManager.Instance.Get("AddFriend"));
                writer.Write("</dd>");
                writer.Write("<dd>");
                GenericRenderer.WriteRightLinkButton(writer, WebUtilities.GetActionJs("AddFriendOrFoe", "Foe", string.Empty, true), LanguageManager.Instance.Get("AddEnemy"));
                writer.Write("</dd>");
            } else {
                writer.Write("<dd>");
                GenericRenderer.WriteRightLinkButton(writer, WebUtilities.GetActionJs("AddFriendOrFoe", "Remove", relation.Id, true), LanguageManager.Instance.Get(string.Format("RemoveFriendOrFoe{0}", relation.IsFriend)));
                writer.Write("</dd>");
            }
           
            writer.Write("</dl>");

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("Actions"));
            Border.RenderSmall("playerActions",mainwriter, title, null, writer.ToString());
        }

        private FriendOrFoe GetRelation(IPlayer player)
        {
            IList<FriendOrFoe> list = Hql.Query<FriendOrFoe>("from SpecializedFriendOrFoe f where f.SourceNHibernate = :source and f.TargetNHibernate =:target", Hql.Param("source", PlayerUtils.Current.Id), Hql.Param("target", player.Id));
            if (list.Count == 0) {
                return null;
            }
            return list[0];
        }

        #endregion Events

    };

}
