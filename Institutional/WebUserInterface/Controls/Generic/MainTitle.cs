using System.Web.UI;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

	public class MainTitle : Control {

		#region Control Events

		protected override void Render(HtmlTextWriter writer) {

            if (State.HasItems("HtmlTitle")) {
                writer.Write(State.GetItems("HtmlTitle"));
            } else {
			    string title = LanguageManager.Instance.Get("FrontPageTitle");
			    if (Page is BasePage) {
				    title = string.Format("{0} - {1}", ((BasePage) Page).PageTitle, title);
			    }
			    writer.Write(title);
            }
		}

		#endregion Control Events

	};

}
