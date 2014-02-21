using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Taurus")]
	public class Taurus: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
			get { return 5000; }
        }

        public override int Defense {
            get { return 6800; }
        }

		public override int Range {
			get { return 3; }
		}

        public override string Name {
			get { return "Taurus"; }
        }

        public override string Code {
            get { return "t"; }
        }

		public override int UnitValue {
			get { return 85; }
		}

        public override int MovementCost {
            get { return 4; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.UnAvailable; }
        }

        public override Race[] Races {
            get { return RaceUtils.LightHumans; }
        }

		public override UnitType UnitType {
			get { return UnitType.Mechanic; }
		}

		public override UnitCategory UnitCategory {
			get { return UnitCategory.Heavy; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Ground; }
		}

		public override MovementType MovementType {
			get { return MovementType.Front; }
		}

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 10);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 2000);
            Cost.Add(this, typeof(Serium), 2500);
            Cost.Add(this, typeof(Mithril), 3000);
            Cost.Add(this, typeof(Argon), 1800);
            Cost.Add(this, typeof(Radon), 900);

        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Taurus)); }
        }

        #endregion Static Utils

    };
}
