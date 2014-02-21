using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("StrikeBackMessage")]
	public class StrikeBackMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new StrikeBackMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public StrikeBackMessage() {}

		public StrikeBackMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit {0} striked back.";
		}

		#endregion Constructor
	}
}
