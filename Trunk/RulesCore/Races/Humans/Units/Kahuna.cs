using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Kahuna")]
	public class Kahuna: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1000; }
		}

		public override int Defense {
			get { return 1300; }
		}

		public override int Range {
			get { return 2; }
		}

		public override string Name {
			get { return "Kahuna"; }
		}

		public override string Code {
			get { return "kh"; }
		}

		public override int UnitValue {
			get { return 42; }
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
			get { return UnitDisplacement.Ground; }
		}

		public override MovementType MovementType {
			get { return MovementType.All; }
		}

        public override int MovementCost
        {
            get { return 2; }
        }

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 5);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1000);
            Cost.Add(this, typeof(Serium), 1100);
            Cost.Add(this, typeof(Mithril), 1400);
            Cost.Add(this, typeof(Argon), 750);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Kahuna)); }
        }

        #endregion Static Utils

    };
}
