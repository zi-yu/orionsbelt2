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
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {

    public class ChooseAvatar : Control {

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WebUtilities.ProcessPostBackAction(this.Page, ChangeAvatar, "Avatar");
        }

        public void ChangeAvatar(string type, string action, string data)
        {
            if (data == string.Empty) {
                ChangeAvatar(ResourcesManager.DefaultAvatar);
            } else if( action=="Unit") {
                IUnitInfo unit = RulesUtils.GetUnit(data);
                ChangeAvatar(ResourcesManager.GetUnitImage(unit));
            } else {
                IIntrinsicInfo resource = RulesUtils.GetIntrinsic(data);
                ChangeAvatar(ResourcesManager.GetResourceImage(resource));
            }
        }

        private void ChangeAvatar(string newAvatar)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();

                Utils.Principal.Avatar = newAvatar;
                persistance.Update(Utils.Principal);
                State.RemoveFileCache(WebUtilities.GetPrincipalAvatarCacheKey(Utils.Principal.Id));

                IList<PlayerStorage> players = Hql.Query<PlayerStorage>("from SpecializedPlayerStorage p where p.PrincipalNHibernate.Id = :id", Hql.Param("id", Utils.Principal.Id));
                using (IPlayerStoragePersistance playerPersistance = Persistance.Instance.GetPlayerStoragePersistance(persistance)) {

                    foreach (PlayerStorage player in players) {
                        player.Avatar = newAvatar;
                        playerPersistance.Update(player);
                        State.RemoveFileCache(WebUtilities.GetPlayerAvatarCacheKey(player.Id));
                    }
                }

                persistance.CommitTransaction();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("ChooseAvatar"));

            StringWriter content = new StringWriter();

            content.Write("<ul id='avatars'>");
            WriteDefaultAvatar(content);
            foreach (IIntrinsicInfo resource in RulesUtils.GetIntrinsicNonConceptualResources()) {
                WriteResource(content, resource);
            }
            foreach (IUnitInfo unit in RulesUtils.GetUnitResources()) {
                WriteUnit(content, unit);
            }
            content.Write("</ul>");

            StringWriter bottom = new StringWriter();
            bottom.Write("<h3>{0}</h3><img src='{1}' alt='{0}' title='{0}' />", LanguageManager.Localize("CurrentAvatar"), Utils.Principal.Avatar);


            writer.Write("<div id='chooseAvatar'");
            Border.RenderNormal(writer, title, content.ToString(),bottom.ToString());
            writer.Write("</div>");

        }

        private void WriteResource(TextWriter writer, IIntrinsicInfo resource)
        {
            string url = ResourcesManager.GetResourceImage(resource);
            WriteImage(writer, "Resource", resource.Name, url);
        }

        private void WriteDefaultAvatar(TextWriter writer)
        {
            WriteImage(writer, string.Empty, string.Empty, ResourcesManager.DefaultAvatar);
        }

        private void WriteUnit(TextWriter writer, IUnitInfo unit)
        {
            string url = ResourcesManager.GetUnitImage(unit);
            WriteImage(writer, "Unit", unit.Name, url);
        }

        private void WriteImage(TextWriter writer, string type, string code, string url)
        {
            writer.Write("<li{0}>", GetSelected(url));
            writer.Write("<a href='{0}'><img src='{1}' /></a>", WebUtilities.GetActionJs("Avatar", type, code, true), url);
            writer.Write("</li>");
        }

        private string GetSelected(string url)
        {
            if (url == Utils.Principal.Avatar) {
                return " class='current'";
            }
            if (url == ResourcesManager.DefaultAvatar && string.IsNullOrEmpty(Utils.Principal.Avatar)) {
                return " class='current'";
            }
            return string.Empty;
        }

        #endregion Events

    };

}
