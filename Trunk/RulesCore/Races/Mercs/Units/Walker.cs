using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Walker")]
	public class Walker : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Medium | AuctionHouseType.Ship;
            }
        }

		public override int Attack {
			get { return 2200; }
		}

		public override int Defense {
			get { return 1500; }
		}

		public override int Range {
			get { return 3; }
		}

		public override string Name {
			get { return "Walker"; }
		}

		public override string Code {
			get { return "wk"; }
		}

		public override int UnitValue {
			get { return 40; }
		}

		public override int MovementCost {
			get { return 3; }
		}

        public override bool IsBuildable {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.UnAvailable; }
        }

        public override Race[] Races {
			get { return RaceUtils.Mercs; }
        }

		public override UnitType UnitType {
			get { return UnitType.Mechanic; }
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

		public override bool IsShowable {
			get { return false; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static IUnitInfo Resource {
			get { return (IUnitInfo)RulesUtils.GetResource(typeof(Walker)); }
        }

        #endregion Static Utils

    };
}
