using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CoolDownMessage")]
	public class CoolDownMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new CoolDownMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public CoolDownMessage() { }

		public CoolDownMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "{2}'s {0} has a remaining cooldown of {1} turn(s).";
		}

		#endregion Constructor
	}
}
