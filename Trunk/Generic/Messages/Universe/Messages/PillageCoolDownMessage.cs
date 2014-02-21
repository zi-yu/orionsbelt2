using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PillageCoolDownMessage")]
	public class PillageCoolDownMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PillageCoolDownMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public PillageCoolDownMessage() { }

		public PillageCoolDownMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cannot pillage planet '{0}' because it is in pillage cooldown.";
		}

		#endregion Constructor
	}
}
