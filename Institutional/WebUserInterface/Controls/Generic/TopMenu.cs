using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

    public class TopMenu : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div id='topMenu'>");

            writer.Write("<ul>");
            WriteOption(writer, "Home", "Default.aspx");
            WriteOption(writer, "Press", "Press.aspx");
            WriteOption(writer, "ScreenShots", "ScreenShots.aspx");
            WriteOption(writer, "ArtWork", "ArtWork.aspx");
            WriteOption(writer, "Blog", "http://blog.orionsbelt.eu");
            WriteOption(writer, "Gazette", "http://gazette.orionsbelt.eu");
            WriteOption(writer, "Manual", string.Format("http://manual.orionsbelt.eu/{0}/", LanguageManager.CurrentLanguage));
            WriteOption(writer, "Translations", "http://lang.orionsbelt.eu/");
            writer.Write("</ul>");

            writer.Write("</div>");
        }

        private void WriteOption(HtmlTextWriter writer, string key, string url)
        {
            string target = string.Format("{0}{1}?Lang={3}", WebUtilities.ApplicationPath, url, LanguageManager.Instance.Get(key), LanguageManager.CurrentLanguage);
            if (url.StartsWith("http")) {
                target = url;
            }
            writer.Write("<li>");
            writer.Write("<a href='{0}'>{1}</a>", target, LanguageManager.Instance.Get(key));
            writer.Write("</li>");
        }

        #endregion Rendering

    };

}
