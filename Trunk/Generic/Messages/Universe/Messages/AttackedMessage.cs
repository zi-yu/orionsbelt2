using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("AttackedMessage")]
	public class AttackedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Battle; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new AttackedMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public AttackedMessage() { }

		public AttackedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' was attacked by player '{1}'!";
		}

		#endregion Constructor
	}
}
