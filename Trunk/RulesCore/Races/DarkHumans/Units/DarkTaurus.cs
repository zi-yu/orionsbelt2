using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("DarkTaurus")]
	public class DarkTaurus: BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship | AuctionHouseType.DarkHuman | AuctionHouseType.Heavy;
            }
        }

        public override int Attack {
			get { return 6800; }
        }

        public override int Defense {
            get { return 3500; }
        }

		public override int Range {
			get { return 3; }
		}

        public override string Name {
            get { return "DarkTaurus"; }
        }

        public override string Code {
            get { return "dt"; }
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
            get { return RaceUtils.DarkHumans; }
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
            Dependency.Add(this, 1, typeof(DominationYard), 10);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();
            Cost.Add(this, typeof(Gold), 3000);
            Cost.Add(this, typeof(Titanium), 2800);
            Cost.Add(this, typeof(Uranium), 4500);
            Cost.Add(this, typeof(Cryptium), 1500);
            Cost.Add(this, typeof(Astatine), 500);
        }

        #endregion BaseResource Implementation

        #region Static Utils

        public static IUnitInfo Resource
        {
            get { return (IUnitInfo)RulesUtils.GetResource(typeof(DarkTaurus)); }
        }

        #endregion Static Utils

    };
}
