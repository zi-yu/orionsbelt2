
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using Institutional.Core;

namespace Institutional.WebComponents.Controls {
	public class RoleVisible : Control {

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

			if( HttpContext.Current.User.IsInRole(Role) ) {
				base.Render( writer );
			}
		}

	}
}
