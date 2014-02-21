using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicStolenMessage")]
	public class RelicStolenMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicStolenMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public RelicStolenMessage() { }

		public RelicStolenMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The Relic at coordinate '{0}' was stolen by player '{1}'.";
		}

		#endregion Constructor
	}
}
