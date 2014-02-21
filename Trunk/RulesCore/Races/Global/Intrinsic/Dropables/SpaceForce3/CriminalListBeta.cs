using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("CriminalListBeta")]
	public class CriminalListBeta : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 3; }
		}

		public override string Name {
			get { return "CriminalListBeta"; }
		}

		public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
		}

		public override int DropRate {
			get {return 5;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(CriminalListBeta)); }
		}

		#endregion Static Utils

	};

}
