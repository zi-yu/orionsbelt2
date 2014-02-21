using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Stinger")]
	public class Stinger: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 500; }
		}

		public override int Defense {
			get { return 1000; }
		}

		public override int Range {
			get { return 2; }
		}

		public override string Name {
            get { return "Stinger"; }
		}

		public override string Code {
			get { return "sg"; }
		}

		public override int UnitValue {
			get { return 32; }
		}

		public override int MovementCost {
			get {return 2;}
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
            Dependency.Add(this, 1, typeof(Incubator), 4);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Protol), 400);
            Cost.Add(this, typeof(Elk), 800);
            Cost.Add(this, typeof(Prismal), 300);
        }

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return 5 * quantity;
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Stinger)); }
        }

        #endregion Static Utils

    };
}
