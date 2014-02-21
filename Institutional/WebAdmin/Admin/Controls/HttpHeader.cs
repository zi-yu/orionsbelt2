using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Institutional.WebAdmin.Admin.Controls {

	public class HttpHeaders : Control {

		protected override void OnLoad( EventArgs e ) {
			HttpContext.Current.Session["CurrentEntity"] = "httpheaders";
			HttpContext.Current.Session["CurrentAction"] = "";
		}

		protected override void Render( HtmlTextWriter writer ) {
			foreach( string s in HttpContext.Current.Request.Headers.AllKeys ) {
				writer.WriteLine( string.Format( "<p><b>{0}:</b> {1}</p>", s, HttpContext.Current.Request.Headers[s] ) );
			}
			base.Render( writer );
		}

	}
	
}