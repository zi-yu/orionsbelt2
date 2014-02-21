using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
    public class BringToolsAndSuppliesToMarketLevel3 : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 5; }
        }

        public override int Bonus {
            get { return 5;  }
        }

        public override int TargetTransactions {
            get { return 1; }
        }

        protected override bool InvalidMarketLevel(OrionsBelt.Core.Market market)
        {
            return !(market.Level == 3 || market.Level == 5);
        }

        public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
                yield return new ResourceQuantity(Tools.Resource,1);
                yield return new ResourceQuantity(Supplies.Resource,1);
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
