using System;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface {
	public class MobInfo : Page {

		protected override void OnPreInit(EventArgs e) {
			base.OnPreInit(e);
			if (!string.IsNullOrEmpty(Request.QueryString["Account"])) {
				MasterPageFile = "~/Account/Account.Master";
			}
		}
	}
}
