using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("PositronCannon")]
	public class PositronCannon : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 10; }
		}

		public override string Name {
			get { return "PositronCannon"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(PositronCannon)); }
		}

		#endregion Static Utils

	};

}
