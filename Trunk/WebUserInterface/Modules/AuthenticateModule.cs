using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Threading;
using System.Globalization;
using System.Security.Principal;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Modules {
	public class AuthenticateModule : IHttpModule {
	
		#region Private

		private static void SetDefaultLanguage() {
			string option = LanguageManager.RequestLanguage;
			SetLanguage( option );
		}

		public static void SetLanguage( string lang ) {
			try {
				if( string.IsNullOrEmpty( lang ) ) {
					lang = "en";
				}
				Thread.CurrentThread.CurrentUICulture = new CultureInfo( lang );
			} catch {}
		}

		private static Principal GetPrincipal( string name ) {
            IList<Principal> p = Hql.Query<Principal>("from SpecializedPrincipal e left join fetch e.PlayerNHibernate p where e.Name = :name and ( p.Active = 1 or p.Active is null )", new KeyValuePair<string, object>("name", name));
            if (p != null && p.Count > 0)  {
                Principal principal = p[0];
                principal.Identity = HttpContext.Current.User.Identity;
                PlayerUtils.SetCurrentPlayer(principal);
				return principal;
            }

            // may be that principal doesn't have an active player... gonna fix that
            IList<Principal> hack = Hql.Query<Principal>("from SpecializedPrincipal e left join fetch e.PlayerNHibernate p where e.Name = :name", new KeyValuePair<string, object>("name", name));
            if (hack != null && hack.Count > 0) {
                Principal principal = hack[0];
                principal.Identity = HttpContext.Current.User.Identity;
                PlayerUtils.SetCurrentPlayer(principal);
                return principal;
            }
			return null;
		}

		private static void AuthenticateUser() {
			HttpContext context = HttpContext.Current;
			string name = context.User.Identity.Name;

        	Principal principal = GetPrincipal(name);
			if( null != principal ) {
				SetLanguage(principal.Locale);
				context.User = principal;
                TouchPrincipal(principal);
			}

            Principal impersonate = GetPrincipalToImpersonate(context);
            if (impersonate != null) {
                context.User = impersonate;
            }
		}

        private static void TouchPrincipal(Principal principal)
        {
            if (principal.UpdatedDate < DateTime.Now.AddMinutes(-30)) {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                    principal.LastLogin = DateTime.Now;
                    persistance.Update(principal);
                    // don't flush, lets wait for another flush on the request
                }
            }
        }

        private static Principal GetPrincipalToImpersonate(HttpContext context)
        {
            if (!context.User.IsInRole("admin")) {
                return null;
            }

            HttpCookie cookie = context.Request.Cookies["Impersonate"];

            if (!string.IsNullOrEmpty(context.Request.QueryString["UnImpersonate"])) {
                HttpCookie icookie = new HttpCookie("Impersonate", string.Empty);
                icookie.Expires = DateTime.Now.AddDays(-1000);
                context.Response.Cookies.Add(icookie);
                icookie.Value = string.Empty;
                if (cookie != null) {
                    cookie.Value = string.Empty;
                }
                return null;
            }

            if (cookie != null && !string.IsNullOrEmpty(cookie.Value)) {
                return GetPrincipal(cookie.Value);
            }

            return null;
        }

		#endregion
		
		#region IHttpModule Members

		public void Init( HttpApplication context ) {
			context.AuthenticateRequest += AuthenticateRequest;
		}

		public void Dispose() {}

		#endregion

		#region Events

		private static void AuthenticateRequest( object sender, EventArgs e ) {
			if( HttpContext.Current.Request.IsAuthenticated ) {
				if( HttpContext.Current.User is Principal ) {
					return;
				}
				AuthenticateUser();
			} else {
				SetDefaultLanguage();
				HttpContext.Current.User = new GenericPrincipal( new GenericIdentity( "guest" ), new string[] { "guest" } );
			}
		}

		#endregion

	}
}
