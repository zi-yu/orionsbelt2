using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("SpaceForceUniformDelta")]
	public class SpaceForceUniformDelta : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
			get { return "SpaceForceUniformDelta"; }
		}

		public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
		}

		public override int DropRate {
			get {return 20;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(SpaceForceUniformDelta)); }
		}

		#endregion Static Utils

	};

}
