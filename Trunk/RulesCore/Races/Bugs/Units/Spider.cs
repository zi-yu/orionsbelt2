using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Spider")]
    public class Spider : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Medium | AuctionHouseType.Bugs;
            }
        }

        public override int Attack {
			get { return 1800; }
		}

		public override int Defense {
			get { return 2200; }
		}

		public override int Range {
			get { return 3; }
		}

		public override string Name {
            get { return "Spider"; }
		}

		public override string Code {
			get { return "sp"; }
		}

		public override int UnitValue {
			get { return 55; }
		}

		public override int MovementCost {
			get { return 2; }
		}

        public override ResourceState InitialState {
            get { return ResourceState.UnAvailable; }
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
            Dependency.Add(this, 1, typeof(Incubator), 7);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 1000);
            Cost.Add(this, typeof(Elk), 1200);
            Cost.Add(this, typeof(Prismal), 900);
            Cost.Add(this, typeof(Radon), 500);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 7 * quantity;
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Spider)); }
        }

        #endregion Static Utils
    };
}
