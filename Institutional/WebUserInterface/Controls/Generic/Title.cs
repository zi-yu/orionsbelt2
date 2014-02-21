using System.Web.UI;

namespace Institutional.WebUserInterface.Controls {

	public class Title : Control {

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {
			if( Page is BasePage ) {
				writer.Write("<div id='pageTitle'>{0}</div>",((BasePage)Page).PageTitle);
			}
		}

		#endregion Control Events

	};

}
