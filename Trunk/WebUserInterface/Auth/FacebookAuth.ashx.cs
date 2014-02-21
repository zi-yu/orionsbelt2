using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Loki.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

    /// <summary>
    /// facebook Authentication Handler
    /// </summary>
    public class FacebookAuth : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            try {
                FacebookSession.CreateSession();
                if (FacebookSession.Instance.IsConnected) {
                    FacebookUser user = FacebookRest.GetCurrentUserInfo();
                    if (user != null) {
                        Principal principal = GetOrCreatePrincipal(user);
                        if (principal != null) {
                            AuthPrincipal(principal);
                        }
                    }
                }
            } catch (Exception e) {
                HttpContext.Current.Response.Write(e.ToString());
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #region Utils

        private Principal GetOrCreatePrincipal(FacebookUser user) {
            string username = string.Format("facebook:{0}", user.Id);
            IList<Principal> list = Hql.Query<Principal>("select principal from SpecializedPrincipal principal where principal.Password = :name", Hql.GetParams(Hql.Param("name", username)));
            if (list.Count > 0) {
                return list[0];
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                persistance.StartTransaction();

                Principal principal = persistance.Create();
                principal.Name = string.Format("facebook{0}:{1} {2}",user.Id, user.FirstName,user.LastName);
                principal.Approved = true;
                principal.Locked = false;
                principal.Password = username;

                persistance.Update(principal);
                persistance.CommitTransaction();
                return principal;
            }
        }

        private void AuthPrincipal(Principal principal) {
            FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(principal.Name, true, 86400);
            string encryptedAuthTicket = FormsAuthentication.Encrypt(authenticationTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedAuthTicket);
            authCookie.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.Cookies.Set(authCookie);
            HttpContext.Current.Response.Redirect("/");
        }

        #endregion Utils
    }
}
