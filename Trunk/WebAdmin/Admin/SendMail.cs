using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Security.Permissions;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Globalization;

namespace OrionsBelt.WebAdmin.Admin.Controls {

	[AspNetHostingPermission( SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal )]
	[AspNetHostingPermission( SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal )]
	public class SendMail : Page {
		
		protected override void OnLoad( EventArgs e ) {
			HttpContext.Current.Session["CurrentEntity"] = "sendmail";
			HttpContext.Current.Session["CurrentAction"] = "";
		}
		
	}
	
}