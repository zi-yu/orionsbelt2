
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Xml.XPath;
using System.IO;

namespace Institutional.Core {

    /// <summary>
    /// Manages hierarchical roles
    /// </summary>
	internal static class RoleManager {

		#region Static

		private static XPathDocument doc = null;

		static RoleManager()
		{
			string file = RolesFile;
			if( !File.Exists(file) ) {
				throw new EntityException("Roles file `{0}' not found", file);
			}
			doc = new XPathDocument(file);
		}

        /// <summary>
        /// The role configuration document
        /// </summary>
		public static XPathDocument Document {
			get { return doc; }
		}

		#endregion Static

		#region Properties

        /// <summary>
        /// Specifies the Roles.xml file location
        /// </summary>
		private static string RolesFile {
			get {
				string fromAppSettings = System.Configuration.ConfigurationManager.AppSettings["Roles.xml"];
				if (!string.IsNullOrEmpty(fromAppSettings)) {
					return fromAppSettings;
				}
				string roleFile = "Roles.xml";
				string path = typeof( RoleManager ).Assembly.CodeBase;
				path = new Uri(path).AbsolutePath;
				path = Path.GetDirectoryName( path );
                path = Path.Combine(path, "..");
                path = Path.Combine(path, "Config");
				roleFile = Path.Combine( path, roleFile );
				return roleFile;
			}
		}

		#endregion

		#region Private

        /// <summary>
        /// Checks if a parent role is accessible
        /// </summary>
        /// <param name="navigator">The navitagor</param>
        /// <param name="targetRole">The wanted role</param>
        /// <returns>True if thr principal has the role</returns>
        private static bool CheckParents(XPathNavigator navigator, string targetRole) 
        {
            string role = GetAttribute(navigator, "name");
			if( role == targetRole ) {
				return true;
			}

			if( navigator.MoveToParent() ) {
                return CheckParents(navigator, targetRole);
			}
			return false;
		}

        /// <summary>
        /// Gets an attribute value
        /// </summary>
        /// <param name="navigator"></param>
        /// <returns></returns>
        private static string GetAttribute(XPathNavigator navigator, string attName)
        {
            return navigator.GetAttribute(attName, string.Empty);
        }

		#endregion
		
		#region Public

        /// <summary>
        /// Checks if a Principal is in the given role
        /// </summary>
        /// <param name="principal">The principal</param>
        /// <param name="role">The wanted role</param>
        /// <returns>True if the principal has authorization</returns>
		public static bool IsInRole( string role, IEnumerable<string> principalRoles ) 
        {
            foreach (string principalRole in principalRoles) {
                if (principalRole == role) {
                    return true;
                }

                XPathNavigator nav = Document.CreateNavigator();
                XPathNodeIterator iter = nav.Select(string.Format("//role[@name='{0}']", role));

                foreach (XPathNavigator navigator in iter) {
                    if (CheckParents(navigator, principalRole )) {
                        return true;
                    }
                }
            }

            return false;
		}
		
		#endregion

	};
}
