using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
    [DesignPatterns.Attributes.FactoryKey("CaptainWolfShipSpecifications")]
    public class CaptainWolfShipSpecifications : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 10; }
		}

		public override string Name {
            get { return "CaptainWolfShipSpecifications"; }
		}

		public override Race[] Races {
			get { return RaceUtils.SpaceForce; }
		}

		public override int DropRate {
			get {return 0;}
		}

		#endregion Properties

		#region Static Utils

		public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(CaptainWolfShipSpecifications)); }
		}

		#endregion Static Utils

	};

}
