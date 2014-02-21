using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has colonized all private zone planets
    /// </summary>
    public class FindOneMarketQuest : MarketCheck  {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 50; }
        }

        public override int TargetLevel {
            get { return 1; }
        }

        public override bool IsProgressive
        {
            get { return false; }
        }

        public override QuestContext Context {
            get { return QuestContext.Merchant; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected override int Count {
            get { return 1; }
        }

        public override int ScoreReward
        {
            get { return 1000; }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards
        {
            get
            {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 200);
                dic.Add(Prismal.Resource, 200);
                dic.Add(Argon.Resource, 200);
                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
