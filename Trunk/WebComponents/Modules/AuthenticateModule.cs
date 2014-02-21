using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Threading;
using System.Globalization;
using System.Security.Principal;

namespace OrionsBelt.WebComponents.Modules {
	public class AuthenticateModule : IHttpModule {
	
		#region Configuration Properties

        /// <summary>
        /// True if this module should auto configure the request's language
        /// </summary>
        public static bool EnableSetLanguage {
            get { return enableSetLanguage; }
            set { enableSetLanguage = value; }
        }
        private static bool enableSetLanguage = true;

        #endregion Configuration Properties
	
		#region Private

		private static void SetDefaultLanguage() {
			string option = LanguageManager.RequestLanguage;
			SetLanguage( option );
		}

		private static void SetLanguage( string lang ) {
			if (!EnableSetLanguage) {
                return;
            }
			try {
				if( string.IsNullOrEmpty( lang ) ) {
					lang = "en";
				}
				Thread.CurrentThread.CurrentUICulture = new CultureInfo( lang );
			} catch {}
		}

		private static Principal GetPrincipal( string name ) {
			IList<Principal> p = Hql.Query<Principal>("from SpecializedPrincipal e where e.Name = :name", new KeyValuePair<string, object>("name", name));
            if (p != null && p.Count > 0)  {
                Principal principal = p[0];
                principal.Identity = HttpContext.Current.User.Identity;
				return principal;
            }
			return null;
		}

		private static void AuthenticateUser() {
			HttpContext context = HttpContext.Current;
			string name = context.User.Identity.Name;

            if( !State.HasUserInMemory(name) ) {
            	Principal principal = GetPrincipal(name);
				if( null != principal ) {
					SetLanguage(principal.Locale);

					context.User = principal;
					State.SetUserInMemory(name, context.User);
				}
			} else {
				Principal cacheUser = (Principal) State.GetUserFromMemory(name);
                HttpContext.Current.User = cacheUser;
                Persistance.PrepareLaziness(cacheUser);
			}
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
