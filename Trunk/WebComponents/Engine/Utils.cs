using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents {
	
	/// <summary>
    /// Context utilities
    /// </summary>
	public class Utils {

		#region Properties

        /// <summary>
        /// Gets the current authenticated principal
        /// </summary>
        public static Principal Principal {
            get { return GetPrincipal(); }
        }

        /// <summary>
        /// Gets the current usar as an admin
        /// </summary>
        public static Principal Admin {
            get { return GetPrincipalWithRole("admin"); }
        }

        #endregion Properties

        #region Utilities

        /// <summary>
        /// Gets the current principal
        /// </summary>
        /// <returns>The principal</returns>
        private static Principal GetPrincipal()
        {
            Principal principal = HttpContext.Current.User as Principal;
            if (principal == null) {
                FormsAuthentication.RedirectToLoginPage("type=unAuthenticated");
                HttpContext.Current.Response.End();
            }

            return principal;
        }
        
        /// <summary>
		/// Verifies if a principal exists
		/// </summary>
		public static bool PrincipalExists {
			get{ return HttpContext.Current != null && HttpContext.Current.User is Principal; }
		}


        /// <summary>
        /// Gets the current principal and asserts the given role
        /// </summary>
        /// <param name="role">The requested role</param>
        /// <returns>The Principal</returns>
        public static Principal GetPrincipalWithRole(string role)
        {
            Principal principal = Principal;
            if (principal.IsInRole(role)) {
                return Principal;
            }

            throw new UnAuthorizedException("Principal isn't `{0}'", role);
        }

        #endregion Utilities
        
        #region Mono

        /// <summary>
        /// True if the application is running under mono
        /// </summary>
        public static bool IsMono {
            get {
                string fromAppSettings = System.Configuration.ConfigurationManager.AppSettings["Mono"];
                if (!string.IsNullOrEmpty(fromAppSettings)) {
                    return bool.Parse(fromAppSettings);
                }
                return false;
            }
        }

        /// <summary>
        /// Sets a css for a given control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="css">The css class</param>
        public static void SetCssClass(System.Web.UI.WebControls.WebControl control, string css)
        {
            if (css == null) {
                return;
            }
            control.CssClass = css;
        }

        #endregion Mono
		
	};

}
