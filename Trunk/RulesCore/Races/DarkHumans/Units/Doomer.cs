using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Doomer")]
    public class Doomer : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
			get { return 6000; }
		}

		public override int Defense {
			get { return 500; }
		}

		public override int Range {
			get { return 3; }
		}

		public override string Name {
            get { return "Doomer"; }
		}

		public override string Code {
			get { return "doo"; }
		}

		public override int UnitValue {
			get { return 68; }
		}

        public override int MovementCost {
            get { return 3; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override Race[] Races {
            get { return RaceUtils.DarkHumans; }
        }

		public override UnitType UnitType {
			get { return UnitType.Mechanic; }
		}

		public override UnitCategory UnitCategory {
			get { return UnitCategory.Heavy; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Diagonal; }
    	}

        public override bool Catapult {
            get { return true; }
        }

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(DominationYard), 8);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 1600);
            Cost.Add(this, typeof(Titanium), 2500);
            Cost.Add(this, typeof(Uranium), 3000);
            Cost.Add(this, typeof(Cryptium), 1000);
            Cost.Add(this, typeof(Argon), 500);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Doomer)); }
        }

        #endregion Static Utils

    };
}
