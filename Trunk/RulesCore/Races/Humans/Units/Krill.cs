using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Krill")]
	public class Krill: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1500; }
        }

        public override int Defense {
			get { return 1000; }
        }

		public override int Range {
			get { return 3; }
		}

        public override string Name {
			get { return "Krill"; }
        }

        public override string Code {
            get { return "kr"; }
        }

		public override int UnitValue {
			get { return 30; }
		}

        public override int MovementCost {
            get { return 2; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.Available; }
        }

        public override Race[] Races {
            get { return RaceUtils.LightHumans; }
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
			get { return MovementType.All; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static Interfaces.IUnitInfo Resource {
            get { return (Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(Krill)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 3);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1500);
            Cost.Add(this, typeof(Serium), 1800);
        }

        #endregion BaseResource Implementation

    };
}
