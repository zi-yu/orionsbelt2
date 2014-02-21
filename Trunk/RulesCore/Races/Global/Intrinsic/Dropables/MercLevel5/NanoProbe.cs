using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("NanoProbe")]
	public class NanoProbe : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 5; }
		}

		public override string Name {
			get { return "NanoProbe"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(NanoProbe)); }
		}

		#endregion Static Utils

	};

}
