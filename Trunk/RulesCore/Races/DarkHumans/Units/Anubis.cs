using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Anubis")]
    public class Anubis : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Light;
            }
        }

        public override int Attack {
			get { return 200; }
		}

		public override int Defense {
			get { return 500; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
            get { return "Anubis"; }
		}

		public override string Code {
			get { return "a"; }
		}

		public override int UnitValue {
			get { return 7; }
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
			get { return UnitCategory.Light; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
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
            Cost.Add(this, typeof(Gold), 1300);
            Cost.Add(this, typeof(Titanium), 1100);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Anubis)); }
        }

        #endregion Static Utils
    };
}
