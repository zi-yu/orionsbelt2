using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("TacticalComputer")]
	public class TacticalComputer : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 25; }
		}

		public override string Name {
			get { return "TacticalComputer"; }
		}

		public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
		}

		public override int DropRate {
			get {return 25;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(TacticalComputer)); }
		}

		#endregion Static Utils

	};

}
