using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("HeavySeeker")]
    public class HeavySeeker : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
            get { return 2500; }
        }

        public override int Defense {
            get { return 2200; }
        }

		public override int Range {
			get { return 5; }
		}

        public override string Name {
            get { return "HeavySeeker"; }
        }

        public override string Code {
            get { return "hr"; }
        }

		public override int UnitValue {
			get { return 65; }
		}

        public override int MovementCost {
            get { return 4; }
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
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Diagonal; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static OrionsBelt.RulesCore.Interfaces.IUnitInfo Resource {
            get { return (OrionsBelt.RulesCore.Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(HeavySeeker)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(Incubator), 8);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 1200);
            Cost.Add(this, typeof(Elk), 1600);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 9 * quantity;
        }

        #endregion BaseResource Implementation

    };
}
