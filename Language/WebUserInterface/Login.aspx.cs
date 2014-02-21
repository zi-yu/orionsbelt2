using System;
using System.Web.Security;

namespace Language.WebUserInterface {
	public partial class Login : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string logout = Page.Request.QueryString["Logout"];
            if (!string.IsNullOrEmpty(logout)) {
                FormsAuthentication.SignOut();
                Page.Response.Redirect("Default.aspx");
            }
        }
		
	}
}
