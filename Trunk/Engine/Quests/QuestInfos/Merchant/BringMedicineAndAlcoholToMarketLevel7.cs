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
    public class BringMedicineAndAlcoholToMarketLevel7 : TradeRouteQuest  {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 8; }
        }

        public override int Bonus {
            get { return 5;  }
        }

        public override int TargetTransactions {
            get { return 1; }
        }

        protected override int TargetMarketLevel {
            get {  return 7; }
        }

        public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
                yield return new ResourceQuantity(Alcohol.Resource,1);
                yield return new ResourceQuantity(Medicine.Resource,1);
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
