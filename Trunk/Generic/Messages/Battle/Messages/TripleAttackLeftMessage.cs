using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("TripleAttackLeftMessage")]
	public class TripleAttackLeftMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new TripleAttackLeftMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public TripleAttackLeftMessage() {}

		public TripleAttackLeftMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Triple Attack attack made {0} of damage to the left that destroyed {1} {2}.";
		}

		#endregion Constructor
	}
}
