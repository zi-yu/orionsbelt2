using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PersonalSettingsMenu : Control {

        #region Events

        protected override void OnInit(System.EventArgs e) {
            base.OnInit(e);
            AccountMenu.CurrentPage = "ChangeMail";
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<ul class='submenu'>");

            writer.Write("<li><a href='{0}Account/ChangeMail.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("PersonalSettings"));
            writer.Write("<li><a href='{0}Account/ChangePassword.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("ChangePassword"));
            writer.Write("<li><a href='{0}Account/Vacations.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("Vacations"));
            writer.Write("<li><a href='{0}Account/Language.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("Language"));
            writer.Write("<li><a href='{0}Account/Invite.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("InviteAFriend"));
            writer.Write("<li><a href='{0}Account/Referrers.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("Referrals"));

            writer.Write("</ul>");
        }

        #endregion Events

    };
}

