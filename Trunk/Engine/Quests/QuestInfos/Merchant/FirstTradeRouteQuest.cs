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
    public class FirstTradeRouteQuest : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 2; }
        }

        public override int TargetTransactions {
            get { return 1; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
