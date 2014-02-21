using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("AntiMatterContainer")]
	public class AntiMatterContainer : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
			get { return "AntiMatterContainer"; }
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
			get { return RulesUtils.GetIntrinsic(typeof(AntiMatterContainer)); }
		}

		#endregion Static Utils

	};

}
