using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

	/// <summary>
	/// Argon resource
	/// </summary>
	[DesignPatterns.Attributes.NoAutoRegister]
	public abstract class DroppableBase : BaseIntrinsic {

		#region Properties

		public override int StartLevel {
			get { return 1; }
		}

		public override AuctionHouseType AuctionType {
			get { return AuctionHouseType.None;}
		}

		public override bool IsRare {
			get { return false; }
		}

		public override bool CanUnloadFromFleet {
			get { return true; }
		}

		public override bool IsDroppable {
			get {return true;}
		}

		#endregion Properties

	};

}
