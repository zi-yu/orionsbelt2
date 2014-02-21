using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("StartBattleMessage")]
	public class StartBattleMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Battle; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new StartBattleMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public StartBattleMessage() {}

		public StartBattleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You started a battle with player '{0}'.";
		}

		#endregion Constructor
	}
}
