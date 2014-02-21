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
    public class Colonize1HotLevel9Quest : HotPlanetsQuest {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 0; }
        }

        public override int TargetLevel {
            get { return 15; }
        }

        protected override int TargetNumberOfPlanets {
            get { return 1; }
        }

        protected override int TargetPlanetsLevel {
            get { return 9; }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 750);
                dic.Add(Radon.Resource, 800);
                dic.Add(Cryptium.Resource, 1000);
                dic.Add(Prismal.Resource, 800);
                dic.Add(Argon.Resource, 1300);
                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
