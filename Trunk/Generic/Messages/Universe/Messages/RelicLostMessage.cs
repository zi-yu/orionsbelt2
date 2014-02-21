using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicLostMessage")]
	public class RelicLostMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicLostMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public RelicLostMessage() { }

		public RelicLostMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The Relic at coordinate '{0}' was lost in battle.";
		}

		#endregion Constructor
	}
}
