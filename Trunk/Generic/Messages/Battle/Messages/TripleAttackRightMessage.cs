using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("TripleAttackRightMessage")]
	public class TripleAttackRightMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new TripleAttackRightMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public TripleAttackRightMessage() {}

		public TripleAttackRightMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Triple Attack attack made {0} of damage to the right that destroyed {1} {2}.";
		}

		#endregion Constructor
	}
}
