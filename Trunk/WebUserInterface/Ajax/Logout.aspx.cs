using System;
using System.Web.Security;
using System.Web;

namespace OrionsBelt.WebUserInterface.Ajax {
	public class Logout: System.Web.UI.Page {

		#region Control Events

		protected override void OnLoad( EventArgs e ) {
			FormsAuthentication.SignOut();
            if (Request.Cookies["Impersonate"] != null) {
                HttpCookie cookie = new HttpCookie("Impersonate", string.Empty);
                cookie.Expires = DateTime.Now.AddDays(-1000);
                Response.Cookies.Add(cookie);
            }
		}

		#endregion Control Events

	}
}
