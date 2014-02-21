using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CancelFleetMovementMessage")]
	public class CancelFleetMovementMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new CancelFleetMovementMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public CancelFleetMovementMessage() { }

		public CancelFleetMovementMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Movement of the fleet '{0}' was cancelled.";
		}

		#endregion Constructor
	}
}
