using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using Institutional.Core;
using Institutional.DataAccessLayer;
using System.Web.UI.WebControls;

namespace Institutional.WebComponents.Controls {
	public class AdminBanner : Control {
		#region Fields
		
		protected LoginStatus loginStatus = new LoginStatus();

 		#endregion		

		#region Private
				
		private void WriteStatus( HtmlTextWriter writer ) {
			writer.Write( "<li><b>Status:</b> " );
			loginStatus.RenderControl( writer );
			writer.Write( "</li>" );
		}

		private string GetExceptionsNumber() {
			using( IExceptionInfoPersistance exceptionInfo = Persistance.Instance.GetExceptionInfoPersistance() ) {
				return exceptionInfo.GetCount().ToString();
			}
		}

		private void Write( HtmlTextWriter writer, string name, string s ) {
			writer.Write( "<li><b>{0}:</b> {1}</li>", name, s );
		}

		#endregion

		#region Overrided

		protected override void Render( HtmlTextWriter writer ) {
			Principal user = (Principal)HttpContext.Current.User;

			writer.Write("<ul id='adminBanner'>");
			WriteStatus( writer );
			Write( writer, "Username", user.Name );
			Write( writer, "Last Login", user.LastLogin.ToString() );
			Write( writer, "Exceptions", string.Format("<a href='/admin/exceptioninfoManage.aspx'>{0}</a>",GetExceptionsNumber()) );
			writer.Write("<li><a href='/admin/'>Admin</a></li>");
			writer.Write("</ul>");

			base.Render( writer );
		}
		
		#endregion
	}
}
