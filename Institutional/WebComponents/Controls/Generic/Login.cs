using System.Web.Security;
using System;
using System.Web;

namespace Institutional.WebComponents.Controls {
	public class Login : System.Web.UI.WebControls.Login {
	
		#region Properties

        private bool alwaysRememberMe = true;

        public bool AlwaysRememberMe {
            get { return alwaysRememberMe; }
            set { alwaysRememberMe = value; }
        }

        #endregion Properties

		#region Private

		private void SetAuthCookie() {
			if( AlwaysRememberMe || RememberMeSet  ) {
				 FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(UserName, true, 86400);
			    string encryptedAuthTicket = FormsAuthentication.Encrypt(authenticationTicket);
			    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedAuthTicket);
			    authCookie.Expires = DateTime.Now.AddMonths(3);
			    HttpContext.Current.Response.Cookies.Set(authCookie);
			} else {
				FormsAuthentication.SetAuthCookie(UserName, false);
			}
		}
		
		#endregion

		#region Overriden

		protected override void OnLoggedIn( EventArgs e ) {
			base.OnLoggedIn(e);
			Page.Session.Clear();

			SetAuthCookie();
		}

		#endregion
		
	}
}
