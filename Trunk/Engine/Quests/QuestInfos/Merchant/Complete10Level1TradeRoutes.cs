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
    public class Complete10Level1TradeRoutes : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 4; }
        }

        public override int TargetTransactions {
            get { return 10; }
        }

        public override int Ticks {
            get {
                return 144;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
