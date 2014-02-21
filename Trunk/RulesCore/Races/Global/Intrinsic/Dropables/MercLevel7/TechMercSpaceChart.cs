using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("TechMercSpaceChart")]
	public class TechMercSpaceChart : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
			get { return "TechMercSpaceChart"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 5;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(TechMercSpaceChart)); }
		}

		#endregion Static Utils

	};

}
