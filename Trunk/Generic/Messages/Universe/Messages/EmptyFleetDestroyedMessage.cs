using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("EmptyFleetDestroyedMessage")]
	public class EmptyFleetDestroyedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new EmptyFleetDestroyedMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public EmptyFleetDestroyedMessage() { }

		public EmptyFleetDestroyedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' was instantaneously destroyed because it was empty.";
		}

		#endregion Constructor
	}
}
