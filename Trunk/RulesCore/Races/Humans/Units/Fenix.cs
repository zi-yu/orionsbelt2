using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Fenix")]
	public class Fenix: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
			get { return 2500; }
        }

        public override int Defense {
			get { return 2950; }
        }

		public override int Range {
			get { return 4; }
		}

        public override string Name {
			get { return "Fenix"; }
        }

        public override string Code {
            get { return "f"; }
        }

		public override int UnitValue {
			get { return 100; }
		}

        public override int MovementCost {
            get { return 3; }
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
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Normal; }
		}

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 9);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1600);
            Cost.Add(this, typeof(Serium), 2000);
            Cost.Add(this, typeof(Mithril), 2400);
            Cost.Add(this, typeof(Argon), 1600);
            Cost.Add(this, typeof(Prismal), 800);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Fenix)); }
        }

        #endregion Static Utils

    };
}
