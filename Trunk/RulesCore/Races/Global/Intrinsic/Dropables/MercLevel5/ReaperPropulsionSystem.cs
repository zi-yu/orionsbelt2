using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("ReaperPropulsionSystem")]
	public class ReaperPropulsionSystem : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 5; }
		}

		public override string Name {
			get { return "ReaperPropulsionSystem"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 15;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(ReaperPropulsionSystem)); }
		}

		#endregion Static Utils

	};

}
