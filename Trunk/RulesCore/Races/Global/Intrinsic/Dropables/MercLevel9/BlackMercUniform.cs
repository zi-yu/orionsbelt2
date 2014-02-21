using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("BlackMercUniform")]
	public class BlackMercUniform : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 9; }
		}

		public override string Name {
			get { return "BlackMercUniform"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 30;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(BlackMercUniform)); }
		}

		#endregion Static Utils

	};

}
