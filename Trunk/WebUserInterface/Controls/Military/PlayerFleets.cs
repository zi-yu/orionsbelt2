using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {
	public class PlayerFleets : ControlBase {

		#region Public

		protected override void Render(HtmlTextWriter writer) {
			PlayerFleetsRenderer.Render(writer);
		}

		#endregion Public
	}
}
