using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using Institutional.WebUserInterface.Controls;
using Institutional.WebComponents;

namespace WebUserInterface {
    public partial class InterGalacticTournamentEN : BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            State.SetItems("HtmlTitle", "2000&euro; in Prizes on the Orion's Belt Intergalactic Tournament!");
        }
    };
}



