using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("DarkCrusader")]
    public class DarkCrusader : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
            get { return 2800; }
        }

        public override int Defense {
            get { return 2000; }
        }

		public override int Range {
			get { return 6; }
		}

        public override string Name {
            get { return "DarkCrusader"; }
        }

        public override string Code {
            get { return "dc"; }
        }

		public override int UnitValue {
			get { return 60; }
		}

        public override int MovementCost {
            get { return 4; }
        }

        public override ResourceState InitialState {
            get { return ResourceState.UnAvailable; }
        }

        public override Race[] Races {
            get { return RaceUtils.DarkHumans; }
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
			get { return MovementType.Front; }
		}

        #endregion BaseUnit Implementation

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(DominationYard), 7);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 2700);
            Cost.Add(this, typeof(Titanium), 3000);
            Cost.Add(this, typeof(Uranium), 3300);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static OrionsBelt.RulesCore.Interfaces.IUnitInfo Resource {
            get { return (OrionsBelt.RulesCore.Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(DarkCrusader)); }
        }

        #endregion Static Utils

    };
}
