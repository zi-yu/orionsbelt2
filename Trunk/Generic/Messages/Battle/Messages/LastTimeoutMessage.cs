using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("LastTimeoutMessage")]
	public class LastTimeoutMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new LastTimeoutMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public LastTimeoutMessage() { }

		public LastTimeoutMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Player '{0}' gave the last timeout. He lost.";
		}

		#endregion Constructor
	}
}
