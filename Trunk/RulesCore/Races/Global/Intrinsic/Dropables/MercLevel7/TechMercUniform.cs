using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("TechMercUniform")]
	public class TechMercUniform : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
			get { return "TechMercUniform"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 25;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(TechMercUniform)); }
		}

		#endregion Static Utils

	};

}
