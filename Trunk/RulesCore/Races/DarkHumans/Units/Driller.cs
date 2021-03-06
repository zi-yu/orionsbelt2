using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Driller")]
    public class Driller : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1500; }
		}

		public override int Defense {
			get { return 1500; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
            get { return "Driller"; }
		}

		public override string Code {
			get { return "d"; }
		}

		public override int UnitValue {
			get { return 32; }
		}

        public override int MovementCost {
            get { return 2; }
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
			get { return UnitCategory.Medium; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Ground; }
		}

		public override MovementType MovementType {
			get { return MovementType.All; }
    	}

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(DominationYard), 3);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 1700);
            Cost.Add(this, typeof(Titanium), 2000);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Driller)); }
        }

        #endregion Static Utils

    };
}
