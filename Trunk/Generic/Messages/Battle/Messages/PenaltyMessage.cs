using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PenaltyMessage")]
	public class PenaltyMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new PenaltyMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public PenaltyMessage() {}

		public PenaltyMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "The attack will have a penalty of {0}% because of the distance (was {1}).";
		}

		#endregion Constructor
	}
}
