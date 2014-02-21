using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has colonized oneaditional planet
    /// </summary>
    public class Owns19ArenaQuest : ArenaCountQuest
    {

        #region BaseQuestInfo Implementation

        protected override int TargetNumberOfArenas {
            get { return 19; }
        }

        public override int TargetLevel
        {
            get { return 18; }
        }

        

        #endregion BaseQuestInfo Implementation

    };

}
