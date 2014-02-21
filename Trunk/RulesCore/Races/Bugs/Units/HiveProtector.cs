using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("HiveProtector")]
	public class HiveProtector: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1000; }
        }

        public override int Defense {
			get { return 4500; }
        }

		public override int Range {
			get { return 3; }
		}

        public override string Name {
            get { return "HiveProtector"; }
        }

        public override string Code {
            get { return "hp"; }
        }

		public override int UnitValue {
			get { 
                #warning needs to be updated when no tournament using HiveProtector is running
                return 5; 
            }
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
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Normal; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static Interfaces.IUnitInfo Resource {
            get { return (Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(HiveProtector)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(Incubator), 5);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 1000);
            Cost.Add(this, typeof(Elk), 800);
            Cost.Add(this, typeof(Prismal), 700);
            Cost.Add(this, typeof(Radon), 500);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 5 * quantity;
        }

        #endregion BaseResource Implementation

    };
}
