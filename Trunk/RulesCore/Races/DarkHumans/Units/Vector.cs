using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Vector")]
    public class Vector : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 2000; }
		}

		public override int Defense {
			get { return 1200; }
		}

		public override int Range {
			get { return 4; }
		}

		public override string Name {
            get { return "Vector"; }
		}

		public override string Code {
			get { return "v"; }
		}

		public override int UnitValue {
			get { return 80; }
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
			get { return UnitCategory.Medium; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Normal; }
    	}

        public override bool Catapult {
            get { return true; }
        }

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(DominationYard), 6);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 1000);
            Cost.Add(this, typeof(Titanium), 800);
            Cost.Add(this, typeof(Uranium), 1200);
            Cost.Add(this, typeof(Cryptium), 500);
            Cost.Add(this, typeof(Radon), 400);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Vector)); }
        }

        #endregion Static Utils

    };
}
