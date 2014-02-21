using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("MystTargetingSystem")]
	public class MystTargetingSystem : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 3; }
		}

		public override string Name {
			get { return "MystTargetingSystem"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(MystTargetingSystem)); }
		}

		#endregion Static Utils

	};

}
