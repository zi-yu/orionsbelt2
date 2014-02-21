using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("SilverBeard")]
	public class SilverBeard : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Boss;
            }
        }

		public override int Attack {
			get { return 50000; }
		}

		public override int Defense {
			get { return 100000; }
		}

		public override int Range {
			get { return 5; }
		}

		public override string Name {
			get { return "SilverBeard"; }
		}

		public override string Code {
			get { return "sb"; }
		}

		public override int UnitValue {
			get { return 25000; }
		}

		public override bool Catapult {
			get {return true;}
		}

		public override int MovementCost {
			get { return 4; }
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
			get { return UnitCategory.Heavy; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Normal; }
    	}

		public override bool IsShowable {
			get { return false; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static IUnitInfo Resource {
			get { return (IUnitInfo)RulesUtils.GetResource(typeof(SilverBeard)); }
        }

        #endregion Static Utils
    };
}
