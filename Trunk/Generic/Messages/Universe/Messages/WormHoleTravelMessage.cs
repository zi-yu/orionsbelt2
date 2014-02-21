using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("WormHoleTravelMessage")]
	public class WormHoleTravelMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.WormHole; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new WormHoleTravelMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public WormHoleTravelMessage() {}

		public WormHoleTravelMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' traveled through a WormHole. It's now at coordinate '{1}'";
		}

		#endregion Constructor
	}
}
