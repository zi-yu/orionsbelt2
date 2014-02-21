using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Egg")]
	public class Egg : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.None;
            }
        }

        public override int Attack {
			get { return 0; }
		}

		public override int Defense {
			get { return 1; }
		}

		public override int Range {
			get { return 0; }
		}

		public override string Name {
			get { return "Egg"; }
		}

		public override string Code {
			get { return "eg"; }
		}

		public override int UnitValue {
			get { return 1; }
		}

		public override int MovementCost {
			get {return 0;}
		}

		public override bool IsBuildable {
			get { return false; }
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
			get { return MovementType.None; }
		}

        public override bool IsShowable{
            get{return false;}
        }

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(QueenHatchery), 3);
        }

        #endregion BaseResource Implementation
    };
}
