using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("BlackMercSpaceChart")]
	public class BlackMercSpaceChart : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 9; }
		}

		public override string Name {
			get { return "BlackMercSpaceChart"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(BlackMercSpaceChart)); }
		}

		#endregion Static Utils

	};

}
