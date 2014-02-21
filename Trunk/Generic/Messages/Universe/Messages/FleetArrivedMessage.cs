using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetArrivedMessage")]
	public class FleetArrivedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetArrivedMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public FleetArrivedMessage() {}

		public FleetArrivedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' arrived to coordinate '{1}'.";
		}

		#endregion Constructor
	}
}
