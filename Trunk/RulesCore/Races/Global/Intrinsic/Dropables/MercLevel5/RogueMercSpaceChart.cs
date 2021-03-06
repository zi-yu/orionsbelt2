using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("RogueMercSpaceChart")]
	public class RogueMercSpaceChart : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 5; }
		}

		public override string Name {
			get { return "RogueMercSpaceChart"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(RogueMercSpaceChart)); }
		}

		#endregion Static Utils

	};

}
