using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Loki.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

	/// <summary>
    /// Authenticates the user on the application
    /// </summary>
	public class TwitterCallback : IHttpHandler {
	
		#region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            OAuthTwitter oAuth = new OAuthTwitter();

            oAuth.AccessTokenGet(context.Request["oauth_token"]);
            if (oAuth.TokenSecret.Length > 0) {
                string url = "http://twitter.com/account/verify_credentials.xml";
                string xml = oAuth.oAuthWebRequest(OAuthTwitter.Method.GET, url, String.Empty);

                TwitterInfo info = SerializerUtils.Import<TwitterInfo>(xml);
                Principal principal = GetOrCreatePrincipal(info);
                AuthPrincipal(principal);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

        #region Utils

        private Principal GetOrCreatePrincipal(TwitterInfo info)
        {
            string username = string.Format("twitter:{0}", info.UserName);
            IList<Principal> list = Hql.Query<Principal>("select principal from SpecializedPrincipal principal where principal.Password = :name", Hql.GetParams(Hql.Param("name", username)));
            if (list.Count > 0) {
                return list[0];
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();

                Principal principal = persistance.Create();
                principal.Name = username;
                principal.Password = username;
                principal.Approved = true;
                principal.Locked = false;
                principal.Avatar = info.Avatar;
                principal.WebSite = string.Format("http://twitter.com/{0}", info.UserName);

                persistance.Update(principal);
                persistance.CommitTransaction();
                return principal;
            }
        }

        private void AuthPrincipal(Principal principal)
        {
            FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(principal.Name, true, 86400);
            string encryptedAuthTicket = FormsAuthentication.Encrypt(authenticationTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedAuthTicket);
            authCookie.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.Cookies.Set(authCookie);
            HttpContext.Current.Response.Redirect("/");
        }

        #endregion Utils
	
	};
}
