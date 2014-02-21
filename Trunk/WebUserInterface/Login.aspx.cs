using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {
	public class Login : Page {

        protected WebComponents.Controls.Login Login1;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                OrionsBelt.WebUserInterface.Modules.AuthenticateModule.SetLanguage(Request.QueryString["lang"]);

            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string lang = string.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
            {
                lang = string.Format("?lang={0}", Request.QueryString["lang"]);
            }
            Button bt = (Button)WebUtilities.FindControl(Page.Controls[0], "loginButton");
            Literal langApp = (Literal)WebUtilities.FindControl(Page.Controls[0], "langAppend");
            bt.Text = LanguageManager.Instance.Get("Login");
            langApp.Text = string.Format("<a href='Register.aspx{1}'>{0}</a>", LanguageManager.Instance.Get("Register"),lang);
        }
    }
}
