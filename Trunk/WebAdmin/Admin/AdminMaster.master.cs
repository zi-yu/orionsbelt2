using System;
using System.Web;
using OrionsBelt.WebAdmin.Admin.Controls;

namespace OrionsBelt.WebAdmin.Admin {
	public partial class AdminMaster : System.Web.UI.MasterPage {

		protected Information errors;
		protected Information information;

		protected override void OnInit( EventArgs e ) {
			HttpContext.Current.Session["CurrentEntity"] = "";
			HttpContext.Current.Session["CurrentAction"] = "";

			Information.InitErrorControl( errors );
			Information.InitInformationControl( information );
		}
	}
}