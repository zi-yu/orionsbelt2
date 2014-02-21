using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PursuitCanceledMessage")]
	public class PursuitCanceledMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PursuitCanceledMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public PursuitCanceledMessage() { }

		public PursuitCanceledMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' canceled it's pursuit. Target is to far away.";
		}

		#endregion Constructor
	}
}
