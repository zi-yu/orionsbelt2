using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("TitanUnitronCannon")]
	public class TitanUnitronCannon : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 10; }
		}

		public override string Name {
			get { return "TitanUnitronCannon"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(TitanUnitronCannon)); }
		}

		#endregion Static Utils

	};

}
