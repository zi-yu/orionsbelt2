using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class CommunityRender : Control {

		#region Private

		private static readonly string[] elements = new string[] { "Blog", "Gazette", "Chat" };
	
		#endregion Private

		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<ul id='community'>");

			foreach (string s in elements) {
				writer.Write("<li>");
				writer.Write("<h2>{0}</h2>", LanguageManager.Localize(s));
				writer.Write("<a href='{0}.aspx'><div class='frame'></div><img src='{1}' class='{2}'/></a>", s, ResourcesManager.GetEtcImage("Fill"), s.ToLower());
				writer.Write(LanguageManager.Localize(s+"Description"));

				string click = string.Format(LanguageManager.Localize("CommunityClick"), s);
				writer.Write("<a class='nomargin' href='{0}.aspx'>{1}</a>", s, click);
				
				writer.Write("</li>");
			}
			
			writer.Write("</ul>");
		}

		#endregion Constrol Fields
	}
}

