using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Maggot")]
	public class Maggot : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.None;
            }
        }

        public override int Attack {
			get { return 500; }
		}

		public override int Defense {
			get { return 1000; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
			get { return "Maggot"; }
		}

		public override string Code {
			get { return "m"; }
		}

		public override int UnitValue {
			get { return 38; }
		}

		public override int MovementCost {
			get {return 1;}
		}

		public override bool CanBeSaved {
			get { return false; }
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

        public override bool IsBuildable {
            get { return false; }
        }

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(QueenHatchery), 3);
        }

        #endregion BaseResource Implementation
    };
}
