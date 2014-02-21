using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	[DesignPatterns.Attributes.FactoryKey("Eagle")]
	public class Eagle: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.Human | AuctionHouseType.Medium;
            }
        }

        public override int Attack {
			get { return 1100; }
		}

		public override int Defense {
			get { return 1200; }
		}

		public override int Range {
			get { return 3; }
		}

		public override string Name {
			get { return "Eagle"; }
		}

		public override string Code {
			get { return "e"; }
		}

		public override int UnitValue {
			get { return 70; }
		}

		public override bool Catapult {
			get {return true;}
		}

		public override int MovementCost {
			get {return 2;}
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
			get { return MovementType.Diagonal; }
		}

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(UnitYard), 6);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Energy), 1000);
            Cost.Add(this, typeof(Serium), 800);
            Cost.Add(this, typeof(Mithril), 1800);
            Cost.Add(this, typeof(Argon), 600);
            Cost.Add(this, typeof(Astatine), 500);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(Eagle)); }
        }

        #endregion Static Utils

    };
}
