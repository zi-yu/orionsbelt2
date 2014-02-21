
using System;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebComponents.Controls {
	public class LoginStatus : Control {
	
		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<ul id='loginStatus' >");

			if( HttpContext.Current.User.IsInRole("guest")) {
				writer.Write("<li><a href='Login.aspx'>{0}</a></li>", LanguageManager.Instance.Get("Login"));
				writer.Write("<li>|</li>");
				writer.Write("<li><a href='Login.aspx'>{0}</a></li>", LanguageManager.Instance.Get("Register"));
				writer.Write("<li></li>");
			}else {
				writer.Write("<li><a href='javascript:Site.logout();'>Logout</a></li>", LanguageManager.Instance.Get("Logout"));
			}

			writer.Write("</ul>");
		}

		#endregion Constrol Fields
		
	}
}
