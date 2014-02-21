using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Cypher")]
    public class Cypher : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.None;
            }
        }

		public override int Attack {
			get { return 1500; }
		}

		public override int Defense {
			get { return 1500; }
		}

		public override int Range {
			get { return 2; }
		}

        public override int MovementCost {
            get { return 2; }
        }

		public override string Name {
            get { return "Cypher"; }
		}

		public override string Code {
			get { return "cp"; }
		}

		public override int UnitValue {
			get { return 30; }
		}

        public override bool IsBuildable {
            get { return false; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.UnAvailable; }
        }

        public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
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
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Cypher)); }
        }

        #endregion Static Utils
    };
}
