using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
    [DesignPatterns.Attributes.FactoryKey("CommanderFoxShipSpecifications")]
    public class CommanderFoxShipSpecifications : DroppableBase {

		#region Properties

		public override int StartLevel {
			get { return 7; }
		}

		public override string Name {
            get { return "CommanderFoxShipSpecifications"; }
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
            get { return RulesUtils.GetIntrinsic(typeof(CommanderFoxShipSpecifications)); }
		}

		#endregion Static Utils

	};

}
