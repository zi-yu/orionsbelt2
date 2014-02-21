using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetStartMovingMessage")]
	public class FleetStartMovingMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetStartMovingMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public FleetStartMovingMessage() { }

		public FleetStartMovingMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' started to move to coordinate '{1}'.";
		}

		#endregion Constructor
	}
}
