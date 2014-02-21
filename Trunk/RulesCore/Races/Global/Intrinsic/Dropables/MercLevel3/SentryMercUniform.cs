using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("SentryMercUniform")]
	public class SentryMercUniform : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 3; }
		}

		public override string Name {
			get { return "SentryMercUniform"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 25;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(SentryMercUniform)); }
		}

		#endregion Static Utils

	};

}
