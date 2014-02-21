using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("HolographicCube")]
	public class HolographicCube : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 3; }
		}

		public override string Name {
			get { return "HolographicCube"; }
		}

		public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
		}

		public override int DropRate {
			get {return 15;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(HolographicCube)); }
		}

		#endregion Static Utils

	};

}
