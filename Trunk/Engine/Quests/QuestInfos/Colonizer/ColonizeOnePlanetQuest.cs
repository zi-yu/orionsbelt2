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
    /// Quest that checks if the player has colonized oneaditional planet
    /// </summary>
    public class ColonizeOnePlanetQuest : PlanetCountQuest {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 5; }
        }

        public override int TargetLevel {
            get { return 0; }
        }

        protected override int TargetNumberOfPlanets {
            get { return 2; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
