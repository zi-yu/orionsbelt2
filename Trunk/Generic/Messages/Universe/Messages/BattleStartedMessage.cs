using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BattleStartedMessage")]
	public class BattleStartedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Battle; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new BattleStartedMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public BattleStartedMessage() { }

		public BattleStartedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "A battle has started at coordinate {0}.";
		}

		#endregion Constructor
	}
}
