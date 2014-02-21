using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("HiveKing")]
    public class HiveKing : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
            get { return 4000; }
        }

        public override int Defense {
            get { return 3200; }
        }

		public override int Range {
			get { return 4; }
		}

        public override string Name {
            get { return "HiveKing"; }
        }

        public override string Code {
            get { return "hk"; }
        }

		public override int UnitValue {
			get { return 75; }
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
			get { return MovementType.Normal; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static OrionsBelt.RulesCore.Interfaces.IUnitInfo Resource {
            get { return (OrionsBelt.RulesCore.Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(HiveKing)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(Incubator), 9);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 3200);
            Cost.Add(this, typeof(Elk), 2600);
            Cost.Add(this, typeof(Prismal), 800);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 11 * quantity;
        }

        #endregion BaseResource Implementation

    };
}
