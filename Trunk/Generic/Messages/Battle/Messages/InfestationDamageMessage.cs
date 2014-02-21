using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("InfestationDamageMessage")]
	public class InfestationDamageMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new InfestationDamageMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public InfestationDamageMessage() {}

		public InfestationDamageMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Unit at coordinate received {0} of damage from infestation. {1} turn(s) remaining.";
		}

		#endregion Constructor
	}
}
