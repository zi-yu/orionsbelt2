using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Scourge")]
	public class Scourge : BaseUnit {

		#region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Medium | AuctionHouseType.Ship;
            }
        }

		public override int Attack {
			get { return 1450; }
		}

		public override int Defense {
			get { return 2000; }
		}

		public override int Range {
			get { return 3; }
		}

        public override bool Catapult {
            get { return true; }
        }

		public override string Name {
			get { return "Scourge"; }
		}

		public override string Code {
			get { return "so"; }
		}

		public override int UnitValue {
			get { return 30; }
		}

		public override int MovementCost {
			get { return 2; }
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
			get { return (IUnitInfo)RulesUtils.GetResource(typeof(Scourge)); }
		}

		#endregion Static Utils
	}
}
