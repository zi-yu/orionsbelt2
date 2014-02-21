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
    /// Quest that checks if the player has found worm holes
    /// </summary>
    public class FindPrivateWormHoleQuest : WormHoleCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 15; }
        }

        public override int TargetLevel {
            get { return 2; }
        }

        protected override bool HotZone {
            get { return true; }
        }

        protected override int Count {
            get { return 2; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
