using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Worm")]
	public class Worm: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Bugs | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1200; }
		}

		public override int Defense {
			get { return 1200; }
		}

		public override int Range {
			get { return 3; }
		}

		public override string Name {
            get { return "Worm"; }
		}

		public override string Code {
			get { return "w"; }
		}

		public override int UnitValue {
			get { return 25; }
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
            Dependency.Add(this, 1, typeof(Incubator), 3);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Elk), 1500);
            Cost.Add(this, typeof(Protol), 1800);
            //Cost.Add(this, typeof(Argon), 800);
            //Cost.Add(this, typeof(Radon), 300);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Worm)); }
        }

        #endregion Static Utils

    };
}
