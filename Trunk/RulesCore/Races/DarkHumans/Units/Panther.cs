using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Panther")]
    public class Panther : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Light;
            }
        }

        public override int Attack {
			get { return 300; }
		}

		public override int Defense {
			get { return 300; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
			get { return "Panther"; }
		}

		public override string Code {
			get { return "p"; }
		}

		public override int UnitValue {
			get { return 11; }
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
            Dependency.Add(this, 1, typeof(DominationYard), 4);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 300);
            Cost.Add(this, typeof(Titanium), 600);
            Cost.Add(this, typeof(Uranium), 1000);
            Cost.Add(this, typeof(Cryptium), 300);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 2 * quantity;
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Panther)); }
        }

        #endregion Static Utils
    };
}
