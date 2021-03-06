using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("ExhaustionSystem")]
	public class ExhaustionSystem : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 3; }
		}

		public override string Name {
			get { return "ExhaustionSystem"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 15;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(ExhaustionSystem)); }
		}

		#endregion Static Utils

	};

}
