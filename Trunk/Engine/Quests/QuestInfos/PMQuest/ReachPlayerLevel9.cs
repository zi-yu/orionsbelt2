using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has a given level
    /// </summary>
    public class ReachPlayerLevel9 : PlayerPlanetLevelCheck {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 8; }
        }

        protected override int TargetPlayerLevel  {
            get { return 9; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
