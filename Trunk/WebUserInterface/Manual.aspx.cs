using System;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface
{
    public class Manual : System.Web.UI.Page
    {
        #region Fields

        protected Literal content;

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        	string path = HttpContext.Current.Request.QueryString["path"];
			content.Text = WebUtilities.WriteFrame(string.Format("http://manual.orionsbelt.eu/{0}/{1}", LanguageManager.CurrentLanguage, path));
        }

        #endregion Events

    };
}
