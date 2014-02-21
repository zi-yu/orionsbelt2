using DesignPatterns.Attributes;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore {

	[FactoryKey("Flag")]
	public class Flag : BaseUnit {

		#region BaseUnit Implementation

		public override int Attack {
			get { return 1; }
		}

		public override int Defense {
			get { return 10000; }
		}

		public override int Range {
			get { return 1; }
		}

		public override string Name {
			get { return "Flag"; }
		}

		public override string Code {
			get { return "fg"; }
		}

		public override int UnitValue {
			get { return 50000; }
		}

		public override int MovementCost {
			get { return 1; }
		}

		public override bool IsShowable {
			get {return false;}
		}

		public override ResourceState InitialState {
			get { return ResourceState.UnAvailable; }
		}

		public override Race[] Races {
			get { return RaceUtils.NoRace; }
		}

		public override UnitType UnitType {
			get { return UnitType.Mechanic; }
		}

		public override UnitCategory UnitCategory {
			get { return UnitCategory.Special; }
		}

		public override UnitDisplacement UnitDisplacement {
			get { return UnitDisplacement.Air; }
		}

		public override MovementType MovementType {
			get { return MovementType.All; }
		}

		#endregion BaseUnit Implementation

	};
}
