using System;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Account
{
    public class NotOk : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ErrorBoard.AddLocalizedMessage("PaymentCancel");
        }

    };
}
