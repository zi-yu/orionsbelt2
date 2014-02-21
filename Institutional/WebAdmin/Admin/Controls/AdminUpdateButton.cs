using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using Institutional.WebComponents.Controls;

namespace Institutional.WebAdmin.Admin.Controls {
	
	public class AdminUpdateButton : UpdateButton {

        #region UpdateButton Implementation

        protected override void OnSuccess(object src, EventArgs args)
        {
            base.OnSuccess(src, args);
            Information.AddInformation("Operation Succeeded");
        }

        protected override void OnFailure(object src, EventArgs args)
        {
            base.OnFailure(src, args);
            Information.AddError("Operation Failed");
        }

        #endregion UpdateButton Implementation

	};
}
