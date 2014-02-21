using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Races {

    [DesignPatterns.Attributes.FactoryKey("Blinker")]
    public class Blinker : BaseUnit {

        #region BaseUnit Implementation

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ultimate | AuctionHouseType.Human | AuctionHouseType.Ship;
            }
        }

        public override int Attack {
            get { return 1000000; }
        }

        public override int Defense {
			get { return 1000000; }
        }

		public override int Range {
			get { return 4; }
		}

        public override string Name {
			get { return "Blinker"; }
        }

        public override string Code {
            get { return "bk"; }
        }

		public override int UnitValue {
			get { return 1000; }
		}

        public override int MovementCost {
            get { return 5; }
        }

		public override int CoolDown{
			get { return 9; }
		}

		public override int AttackCost {
			get { return 6; }
		}

		public override bool CanAttack {
			get { return false; }
		}

		public override bool IsUltimate {
			get { return true; }
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
			get { return UnitCategory.Ultimate; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.None; }
		}

        #endregion BaseUnit Implementation

        #region Static Utils

        public static OrionsBelt.RulesCore.Interfaces.IUnitInfo Resource {
			get { return (OrionsBelt.RulesCore.Interfaces.IUnitInfo)RulesUtils.GetResource(typeof(Blinker)); }
        }

        #endregion Static Utils

        #region BaseResource Implementation

        protected override void BuildDependecyRules()
        {
            base.BuildDependecyRules();
            Dependency.Add(this, 1, typeof(BlinkerAssembler), 1);
        }

        protected override void BuildCostRules()
        {
            base.BuildCostRules();

            Cost.Add(this, typeof(Energy), 87000);
            Cost.Add(this, typeof(Serium), 89000);
            Cost.Add(this, typeof(Mithril), 101000);
            Cost.Add(this, typeof(Argon), 6900 * 5);
            Cost.Add(this, typeof(Radon), 5500 * 5);
            Cost.Add(this, typeof(Prismal), 5800 * 5);
            Cost.Add(this, typeof(Astatine), 4900 * 5);
            Cost.Add(this, typeof(Cryptium), 1800 * 5);

            UltimateUnitRestriction.Add(this);
        }

        #endregion BaseResource Implementation

    };
}
