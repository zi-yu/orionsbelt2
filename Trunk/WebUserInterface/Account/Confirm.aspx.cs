using System;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Account
{
    public class Confirm : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InformationBoard.AddLocalizedMessage("Thanks");
        }

    };
}
