using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Reaper")]
	public class Reaper : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Light | AuctionHouseType.Ship;
            }
        }

		public override int Attack {
			get { return 500; }
		}

		public override int Defense {
			get { return 250; }
		}

		public override int Range {
			get { return 2; }
		}

		public override string Name {
			get { return "Reaper"; }
		}

		public override string Code {
			get { return "re"; }
		}

		public override int UnitValue {
			get { return 20; }
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
			get { return UnitCategory.Light; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Diagonal; }
    	}

		public override bool IsShowable {
			get { return false; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static IUnitInfo Resource {
			get { return (IUnitInfo)RulesUtils.GetResource(typeof(Reaper)); }
        }

        #endregion Static Utils
    };
}
