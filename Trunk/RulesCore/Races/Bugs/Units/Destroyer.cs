using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Destroyer")]
    public class Destroyer : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1100; }
		}

		public override int Defense {
			get { return 500; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
            get { return "Destroyer"; }
		}

		public override string Code {
			get { return "dy"; }
		}

		public override int UnitValue {
			get { return 42; }
		}

        public override int MovementCost {
            get { return 2; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override Race[] Races {
            get { return RaceUtils.Bugs; }
        }

		public override UnitType UnitType {
			get { return UnitType.Organic; }
		}

		public override UnitCategory UnitCategory {
			get { return UnitCategory.Medium; }
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
            Dependency.Add(this, 1, typeof(Incubator), 6);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 800);
            Cost.Add(this, typeof(Elk), 1000);
            Cost.Add(this, typeof(Prismal), 400);
            Cost.Add(this, typeof(Cryptium), 280);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 7 * quantity;
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Destroyer)); }
        }

        #endregion Static Utils
    };
}
