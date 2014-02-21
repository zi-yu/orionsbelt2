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
using System.IO;

namespace Manual
{
    public partial class Manual : System.Web.UI.MasterPage
    {
        #region Properties

        public string ResourcesLocation {
            get { 
#if DEBUG
                return "http://localhost/WebResources";
#else
                return "http://resources.orionsbelt.eu";
#endif
            }
        }

        public string EngineCSS {
            get {
                return string.Format("<link rel='stylesheet' media='screen' type='text/css' href='{0}/Styles/v/Engine.css?v=manual-1'></link>", ResourcesLocation);
            }
        }

        public string EngineJS {
            get {
                return string.Format("<script src='{0}/Scripts/v/Engine.js?v=manual-1' type='text/javascript' ></script> ", ResourcesLocation);
            }
        }

        #endregion Properties

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterHiddenField("path", "/");
            Page.ClientScript.RegisterHiddenField("imagePath", "http://resources.orionsbelt.eu/Images/Common");
            SetFlags();
            SetTopMenu();
        }

        private void SetTopMenu()
        {
            StringWriter writer = new StringWriter();

            writer.Write("<div id='topMenu'>");
            writer.Write("<ul>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/Default.aspx'>Play!</a></li>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/Press.aspx'>Press</a></li>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/ScreenShots.aspx'>Screen Shots</a></li>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/ArtWork.aspx'>Art Work</a></li>");
            writer.Write("<li><a href='http://blog.orionsbelt.eu'>Blog</a></li>");
            writer.Write("<li><a href='http://gazette.orionsbelt.eu'>Gazette</a></li>");
            writer.Write("<li><a href='http://manual.orionsbelt.eu'>Manual</a></li>");
            writer.Write("<li><a href='http://lang.orionsbelt.eu'>Translations</a></li>");
            writer.Write("</ul>");
            writer.Write("</div>");

            topMenu.Text = writer.ToString();
        }

        private void SetFlags()
        {
            StringWriter writer = new StringWriter();

            writer.Write("<ul class='flags'>");
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/en.gif' alt='en' /></a></li>", GetLangUrl("en/"));
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/de.gif' alt='de' /></a></li>", GetLangUrl("de/"));
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/pt.gif' alt='pt' /></a></li>", GetLangUrl("pt/"));
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/es.gif' alt='es' /></a></li>", GetLangUrl("es/"));
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/hr.gif' alt='hr' /></a></li>", GetLangUrl("hr/"));
            writer.Write("<li><a href='{0}'><img src='http://resources.orionsbelt.eu/Images/Common/Flags/fr.gif' alt='fr' /></a></li>", GetLangUrl("fr/"));
            writer.Write("</ul><div class='clear'></div>");

            flags.Text = writer.ToString();
        }

        private string GetLangUrl(string lang)
        {
            StringWriter writer = new StringWriter();

            for (int i = 0; i < Request.Url.Segments.Length; ++i) {
                if (i == 1) {
                    writer.Write(lang);
                } else {
                    writer.Write(Request.Url.Segments[i]);
                }
            }

            return writer.ToString();
        }

        #endregion Events
    }
}
