using System.Web.UI;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {
	public class GenericButton : Control {

		#region Fields

		protected string clientClick;
		protected string textToken;

		#endregion Fields

		#region Protected

		public string ClientClick {
			get{ return clientClick; }
			set{ clientClick = value;}
		}

		public string TextToken {
			get { return textToken; }
			set { textToken = value; }
		}

		#endregion Protected

		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<div class='center'>");
			writer.Write("<input type='button' class='button'");
			if (!string.IsNullOrEmpty(TextToken)) {
				writer.Write(" value='{0}' ",LanguageManager.Instance.Get(TextToken));
			}
			if (!string.IsNullOrEmpty(ClientClick)) {
				writer.Write(" onclick='{0}' ", ClientClick);
			}
			writer.Write("/></div>");
		}

		#endregion Constrol Fields
	}
}

