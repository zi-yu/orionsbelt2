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

    public class TeamLadderMenu : MenuBase {

        #region Constructor

        public TeamLadderMenu() {
            options = new string[] { "Tournaments/Team.aspx", "LadderTeamList.aspx" };
            optionsLabel = new string[] { "Team", "LadderTeam" };
        }

        #endregion Constructor
    }
}