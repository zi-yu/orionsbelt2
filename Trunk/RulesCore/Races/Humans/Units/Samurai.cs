using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Samurai")]
	public class Samurai: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Light;
            }
        }

        public override int Attack {
			get { return 150; }
		}

		public override int Defense {
			get { return 450; }
		}

		public override int Range {
			get { return 2; }
		}

		public override string Name {
			get { return "Samurai"; }
		}

		public override string Code {
			get { return "s"; }
		}

		public override int UnitValue {
			get { return 15; }
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
			get { return UnitCategory.Light; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.All; }
    	}

        public override bool Catapult {
            get {
                return true;
            }
        }

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 3);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1300);
            Cost.Add(this, typeof(Serium), 1100);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Samurai)); }
        }

        #endregion Static Utils
    };
}
