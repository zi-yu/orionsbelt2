using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.FactoryKey("DarkMercSpaceChart")]
	public class DarkMercSpaceChart : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 10; }
		}

		public override string Name {
			get { return "DarkMercSpaceChart"; }
		}

		public override Race[] Races {
			get { return RaceUtils.Mercs; }
		}

		public override int DropRate {
			get {return 10;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
			get { return RulesUtils.GetIntrinsic(typeof(DarkMercSpaceChart)); }
		}

		#endregion Static Utils

	};

}
