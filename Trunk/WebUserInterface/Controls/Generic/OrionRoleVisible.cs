using System.Web.UI;
using System.Web;
using OrionsBelt.Generic.Log;
using System;

namespace OrionsBelt.WebUserInterface.Controls {
    public class OrionRoleVisible : Control {
		#region Fields

		private string role;

		#endregion

		#region Properties

		public string Role {
			get { return role; }
			set { role = value; }
		}
	
		#endregion

		protected override void Render( HtmlTextWriter writer ) {
			if( string.IsNullOrEmpty( Role ) ) {
				throw new Exception( "Role is not set at RoleVisible" );
			}
            
            Logger.Info("Role is {0}", Role);
            Logger.Info("User is {0}", HttpContext.Current.User.Identity.Name);
            Logger.Info("User type is {0}", HttpContext.Current.User.GetType().Name);
            Logger.Info("User is in Role: {0}", HttpContext.Current.User.IsInRole(Role));

			if( HttpContext.Current.User.IsInRole(Role) ) {
				base.Render( writer );
			}
		}

    }
}
