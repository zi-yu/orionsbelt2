using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("EndTeamBattleMessage")]
	public class  EndTeamBattleMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
            return new EndTeamBattleMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public  EndTeamBattleMessage() { }

        public EndTeamBattleMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "The battle ended. Team {0} won.";
		}

		#endregion Constructor
	}
}
