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

	public class TopsMenu : MenuBase {

        #region Constructor

        public TopsMenu(){
            options = new string[] { "Tops/Score.aspx", "Tops/Elo.aspx", "Tops/EloTeam.aspx", "Tops/Ladder.aspx", "Tops/LadderTeam.aspx", "Tops/Professions.aspx", "Tops/Alliance.aspx", "SearchPlayers.aspx" };
            optionsLabel = new string[] { "TopByScore", "TopByElo", "TopByEloTeam", "TopByLadder", "TopByLadderTeam", "TopByProfessions", "TopByAlliance", "SearchPlayer" };
        }

        #endregion Constructor
    }
}