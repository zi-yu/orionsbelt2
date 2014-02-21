using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BombAttackDamageMessage")]
	public class BombAttackDamageMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new BombAttackDamageMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public BombAttackDamageMessage() { }

		public BombAttackDamageMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Bomb Attack made {0} of damage to the unit at coordinate {1} that destroyed {2} {3}.";
		}

		#endregion Constructor
	}
}
