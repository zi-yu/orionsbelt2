using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Institutional.WebUserInterface.Controls {

    public class FlagMenu : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<ul id='flags'>");
            WriteFlag(writer, "en");
            //WriteFlag(writer, "en", "us");
            //WriteFlag(writer, "en", "gb");
            WriteFlag(writer, "fr");
            WriteFlag(writer, "it");
            WriteFlag(writer, "es", "es");
            WriteFlag(writer, "en", "de");
            WriteFlag(writer, "pt");
            WriteFlag(writer, "pt", "br");
            WriteFlag(writer, "hr");
            WriteFlag(writer, "hr", "rs");  // Serbia
            WriteFlag(writer, "hr", "ba");  // Bosnia and Herzegovina 
            WriteFlag(writer, "ro", "ro");  // Romania
            WriteFlag(writer, "hu", "hu");  // Hungarian
            writer.Write("</ul>");
        }

        private void WriteFlag(HtmlTextWriter writer, string lang)
        {
            WriteFlag(writer, lang, lang);
        }

        private void WriteFlag(HtmlTextWriter writer, string lang, string flag)
        {
            writer.Write("<li>");
            writer.Write("<a href='{0}' title='{1}'>", GetLangUrl(lang), flag);
            writer.Write("<img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' alt='{0}'/>", flag, lang);
            writer.Write("</a>");
            writer.Write("</li>");
        }

        private string GetLangUrl(string lang)
        {
            return string.Format("{0}?Lang={1}", WebUtilities.ApplicationPath, lang);
        }

        #endregion Rendering

    };

}
