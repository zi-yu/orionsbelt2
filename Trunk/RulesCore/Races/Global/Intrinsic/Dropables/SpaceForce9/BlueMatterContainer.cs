using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
    [DesignPatterns.Attributes.FactoryKey("BlueMatterContainer")]
    public class BlueMatterContainer : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 9; }
		}

		public override string Name {
            get { return "BlueMatterContainer"; }
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
            get { return RulesUtils.GetIntrinsic(typeof(BlueMatterContainer)); }
		}

		#endregion Static Utils

	};

}
