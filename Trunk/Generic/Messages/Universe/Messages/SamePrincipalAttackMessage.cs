using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("SamePrincipalAttackMessage")]
	public class SamePrincipalAttackMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Player; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new SamePrincipalAttackMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public SamePrincipalAttackMessage() { }

        public SamePrincipalAttackMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cannot attack because player '{0}' is owned by you.";
		}

		#endregion Constructor
	}
}
