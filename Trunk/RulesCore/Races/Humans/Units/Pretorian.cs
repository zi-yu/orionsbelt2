using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Pretorian")]
	public class Pretorian: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 450; }
        }

        public override int Defense {
			get { return 5550; }
        }

		public override int Range {
			get { return 3; }
		}

        public override string Name {
			get { return "Pretorian"; }
        }

        public override string Code {
            get { return "h"; }
        }

		public override int UnitValue {
			get { return 48; }
		}

        public override int MovementCost {
            get { return 2; }
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
			get { return UnitCategory.Medium; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.Diagonal; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static Interfaces.IUnitInfo Resource {
            get { return (Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(Pretorian)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 4);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1400);
            Cost.Add(this, typeof(Serium), 1000);
            Cost.Add(this, typeof(Argon), 700);
            Cost.Add(this, typeof(Radon), 400);
        }

        #endregion BaseResource Implementation

    };
}
