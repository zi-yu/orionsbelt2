using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("SpaceForceUniformGamma")]
	public class SpaceForceUniformGamma : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 5; }
		}

		public override string Name {
			get { return "SpaceForceUniformGamma"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(SpaceForceUniformGamma)); }
		}

		#endregion Static Utils

	};

}
