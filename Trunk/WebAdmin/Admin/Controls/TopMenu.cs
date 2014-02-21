using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace OrionsBelt.WebAdmin.Admin.Controls {
	public class TopMenu : Control {

		#region Fields
		
		private string[] array = { "Home", "Create", "Manage", "Search" }; 

		#endregion

		#region Private

		private string GetUrl( string s ) {
			string entity = HttpContext.Current.Session["CurrentEntity"].ToString();
			return string.Format("{0}{1}.aspx", entity, s );
		}

		private void WriteMenu( HtmlTextWriter writer, object entity ) {
			if( entity != null && entity.ToString() != string.Empty ) {
				object action = HttpContext.Current.Session["CurrentAction"];
				if( action != null && action.ToString() != string.Empty ) {
					string a = action.ToString();
					foreach( string s in array ) {
						if( action != null && s == a ) {
							writer.WriteLine( "<li><a class='active' href='{0}'>{1}</a></li>", GetUrl( s ), s );
						} else {
							writer.WriteLine( "<li><a href='{0}'>{1}</a></li>", GetUrl( s ), s );
						}
					}
				}
			}
		} 

		#endregion

		#region Overriden Methods
		
		protected override void OnLoad( EventArgs e ) {
			LoginStatus l = new LoginStatus();
			Controls.Add(l);
			base.OnLoad(e);
		}
		
		protected override void Render( HtmlTextWriter writer ) {
			object entity = HttpContext.Current.Session["CurrentEntity"];
			writer.WriteLine( "<div id='nav'>" );
			writer.WriteLine( "<ul>" );

			WriteMenu( writer, entity );

			writer.WriteLine( "<li class='time'>Server Time: {0}</li>", DateTime.Now.ToString( "HH:mm" ) );
			writer.WriteLine("<li class='logout'><a href='..'>Application</a></li>");
			writer.WriteLine("<li class='logout'>");

			base.Render(writer);

			writer.WriteLine("</li'>");
			
			writer.WriteLine( "</ul>" );
			writer.WriteLine( "</div>" );
		}

		#endregion
	}
}