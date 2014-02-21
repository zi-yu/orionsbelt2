using System.Web.UI;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

    public abstract class BasePage : Page {

		#region Fields

		protected string pageTitle;

		#endregion Fields

		#region Properties

    	public string PageTitle {
			get { return pageTitle; }
    	}

		#endregion Properties

		#region Control Events

		protected override void OnInit(System.EventArgs e) {
			pageTitle = LanguageManager.Instance.Get(GetType().BaseType.Name);
		}

		#endregion Control Events

	};

}
