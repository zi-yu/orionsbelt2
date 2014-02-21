using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicAttackedMessage")]
	public class RelicAttackedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicAttackedMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public RelicAttackedMessage() { }

		public RelicAttackedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Relic at coordinate '{0}' was attacked by player '{1}'!";
		}

		#endregion Constructor
	}
}
