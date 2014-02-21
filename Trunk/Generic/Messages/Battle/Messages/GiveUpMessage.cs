using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("GiveUpMessage")]
	public class GiveUpMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new GiveUpMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public GiveUpMessage() {}

		public GiveUpMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Player '{0}' gave up.";
		}

		#endregion Constructor
	}
}
