using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
    public class Complete12Level7TradeRoutes : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 9; }
        }

        public override int TargetTransactions {
            get { return 12; }
        }

        protected override int TargetMarketLevel {
            get { return 7; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
