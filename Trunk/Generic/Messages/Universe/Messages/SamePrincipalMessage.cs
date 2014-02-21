using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("SamePrincipalRaidedMessage")]
	public class SamePrincipalRaidedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Player; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new SamePrincipalRaidedMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public SamePrincipalRaidedMessage() { }

		public SamePrincipalRaidedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cannot raid planet '{0}' because player '{1}' is owned by you.";
		}

		#endregion Constructor
	}
}
