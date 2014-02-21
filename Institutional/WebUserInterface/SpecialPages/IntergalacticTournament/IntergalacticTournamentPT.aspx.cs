using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using Institutional.WebUserInterface.Controls;
using Institutional.WebComponents;
using System.Globalization;

namespace WebUserInterface {
    public partial class IntergalacticTournamentPT : BasePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            LanguageManager.CurrentCulture = new CultureInfo("pt");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            State.SetItems("HtmlTitle", "2000&euro; em Prémios no Torneio Intergaláctico Orion's Belt!");
        }
    };
}



