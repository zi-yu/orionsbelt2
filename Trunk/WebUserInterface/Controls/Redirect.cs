using System.Web;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Redirect : Control {

		#region Fields

		#endregion Fields

		#region Control Implementation
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
		if (HttpContext.Current.User.IsInRole("user")){
                HttpContext.Current.Response.Redirect("Default.aspx", true);
            }
        }

		#endregion Control Implementation

	}
}
