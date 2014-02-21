using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class TournamentTopMenu : MenuBase {

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
            if (Utils.Principal.IsInRole("admin")) {
                options = new string[] { "Tournaments/CreateTournament.aspx"};
                optionsLabel = new string[] { "CreateTournament" };
 	            base.Render(writer);
            }
        }

        #endregion Control Events

    }
}