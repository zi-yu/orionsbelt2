using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("BlackWidow")]
    public class BlackWidow : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Heavy | AuctionHouseType.Bugs;
            }
        }

        public override int Attack {
			get { return 2500; }
		}

		public override int Defense {
			get { return 2100; }
		}

		public override int Range {
			get { return 4; }
		}

		public override string Name {
			get { return "BlackWidow"; }
		}

		public override string Code {
			get { return "b"; }
		}

		public override int UnitValue {
			get { return 80; }
		}

		public override int MovementCost {
			get { return 3; }
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
			get { return UnitCategory.Heavy; }
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
            Dependency.Add(this, 1, typeof(Incubator), 10);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 3000);
            Cost.Add(this, typeof(Elk), 4000);
            Cost.Add(this, typeof(Prismal), 1800);
            Cost.Add(this, typeof(Cryptium), 1000);
            Cost.Add(this, typeof(Astatine), 800);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 12 * quantity;
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(BlackWidow)); }
        }

        #endregion Static Utils

    };
}
