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
    public class Colonize5HotLevel5Quest : HotPlanetsQuest {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 0; }
        }

        public override int TargetLevel {
            get { return 10; }
        }

        protected override int TargetNumberOfPlanets {
            get { return 5; }
        }

        protected override int TargetPlanetsLevel {
            get { return 5; }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Prismal.Resource, 800);
                dic.Add(Radon.Resource, 500);
                dic.Add(Cryptium.Resource, 300);
                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
