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
    public class Colonize8HotLevel7Quest : HotPlanetsQuest {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 0; }
        }

        public override int TargetLevel {
            get { return 14; }
        }

        protected override int TargetNumberOfPlanets {
            get { return 8; }
        }

        protected override int TargetPlanetsLevel {
            get { return 7; }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 900);
                dic.Add(Radon.Resource, 600);
                dic.Add(Prismal.Resource, 1200);
                dic.Add(Argon.Resource, 800);
                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
