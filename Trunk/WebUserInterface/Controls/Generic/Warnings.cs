using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine;
using System;
using OrionsBelt.WebUserInterface.Account;
using System.IO;
using OrionsBelt.Generic;


namespace OrionsBelt.WebUserInterface.Controls {
    public class Warnings : ControlBase{

        #region Private

		private static string FormatDate() {
            DateTime t = Utils.Principal.RegistDate.AddDays(5);
            if (DateTime.Now > t){
                WebUtilities.RedirectToContacts("Locked"); 
            }
            TimeSpan span = t-Utils.Principal.RegistDate;
            return TimeFormatter.GetFormattedTime(span);;
        }

		private static void WriteTable(HtmlTextWriter writer, string title, string text) {
            writer.Write("<table class='table'>");
            writer.Write("<tr><th>{0}</th></tr>", title);
            writer.Write("<tr><td>{0}</td></tr>", text);
            writer.Write("</table>");
        }

		private static void WriteNotApproved(HtmlTextWriter writer) {
            if (Utils.PrincipalExists && !Utils.Principal.Approved) {
                string title = LanguageManager.Instance.Get("NotAprovedAccountTitle");
                string text = string.Format(LanguageManager.Instance.Get("NotAprovedAccount"), Utils.Principal.DisplayName, FormatDate() );
                FramesHtml.FrameHtmlTitle(writer,"accountNotApproved",title,text);
            }
        }

        private static void WriteBlocked()
        {
            if (Utils.PrincipalExists && Utils.Principal.Locked)
            {
                WebUtilities.RedirectToContacts("Blocked");
            }
        }

		private static void WriteVacationsNotice(HtmlTextWriter writer) {
            if (Utils.PrincipalExists && Utils.Principal.VacationStartTick > 0) {
                string title = LanguageManager.Instance.Get("YouAreOnVacationsTitle");
                string text = string.Format("<div class='center'><a href='{0}Account/Vacations.aspx'>{1}</a></div>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("YouAreOnVacations"));
                
                FramesHtml.FrameHtmlTitle(writer,"vacationsWarning",title,text);
            }
        }

        private static void WriteDevNotice(HtmlTextWriter writer){
            if (Server.IsDev) {
                string title = "Development Server";
                string text = "This is a development server. You can play here, but this server will have less players and will be more unstable. You should register at a production server <a href='http://www.orionsbelt.eu/'>here</a>";
                WriteTable(writer, title, text);
            }
        }

        #endregion

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
            WriteNotApproved(writer);
            WriteBlocked();
            WriteVacationsNotice(writer);
            WriteDevNotice(writer);
        }

        #endregion Control Events


    }
}