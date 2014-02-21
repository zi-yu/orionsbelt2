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
    public class Complete8Level3TradeRoutes : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 6; }
        }

        public override int TargetTransactions {
            get { return 8; }
        }

        public override int TargetResourceLevel {
            get { return 3; }
        }

        protected override bool InvalidMarketLevel(OrionsBelt.Core.Market market)
        {
            return !(market.Level == 3 || market.Level == 5);
        }

        #endregion BaseQuestInfo Implementation

    };

}
