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
    public class Colonize1HotLevel1QuestDark : Colonize1HotLevel1Quest {

        #region BaseQuestInfo Implementation

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(DarkRain.Resource, 3);
                return dic;
            }
        }

        public override IRaceInfo TargetRace {
            get {
                return RaceInfo.DarkHumans;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
