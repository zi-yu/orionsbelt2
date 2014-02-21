using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CoolDownEndedMessage")]
	public class CoolDownEndedMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new CoolDownEndedMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public CoolDownEndedMessage() { }

		public CoolDownEndedMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Cooldown of {1}'s {0} has ended.";
		}

		#endregion Constructor
	}
}
