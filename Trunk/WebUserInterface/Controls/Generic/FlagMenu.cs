using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{

    public class FlagMenu : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<ul id='flags'>");
            WriteFlag(writer, "de");
            WriteFlag(writer, "en");
            WriteFlag(writer, "en", "us");
            WriteFlag(writer, "en", "gb");
            WriteFlag(writer, "fr", "fr");
            WriteFlag(writer, "es", "es");
            WriteFlag(writer, "hr");
            WriteFlag(writer, "pt");
            WriteFlag(writer, "pt", "br");
            writer.Write("</ul>");
        }

        private static void WriteFlag(TextWriter writer, string lang)
        {
            WriteFlag(writer, lang, lang);
        }

        private static void WriteFlag(TextWriter writer, string lang, string flag)
        {
            writer.Write("<li>");
            writer.Write("<a href='{0}' title='{1}'>", GetLangUrl(lang), flag);
            writer.Write("<img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' alt='{0}'/>", flag);
            writer.Write("</a>");
            writer.Write("</li>");
        }

        private static string GetLangUrl(string lang)
        {
            return string.Format("{0}?lang={1}", HttpContext.Current.Request.Url.AbsolutePath, lang);
        }

        #endregion Rendering

    };

}
