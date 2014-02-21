using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Sentry")]
	public class Sentry : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Light | AuctionHouseType.Ship;
            }
        }

		public override int Attack {
			get { return 200; }
		}

		public override int Defense {
			get { return 100; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
			get { return "Sentry"; }
		}

		public override string Code {
			get { return "st"; }
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
			get { return MovementType.All; }
    	}

		public override bool IsShowable {
			get { return false; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static IUnitInfo Resource {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Sentry)); }
        }

        #endregion Static Utils
    };
}
