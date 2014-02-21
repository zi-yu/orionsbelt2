using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("ScourgeCoreSystem")]
	public class ScourgeCoreSystem : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
			get { return "ScourgeCoreSystem"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 20;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(ScourgeCoreSystem)); }
		}

		#endregion Static Utils

	};

}
