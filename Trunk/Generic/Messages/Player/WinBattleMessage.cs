using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("WinBattleMessage")]
	public class WinBattleMessage : PlayerMessage {
		
		#region Overriden

        protected override IMessage CreateMessage(int ownerId, params object[] p){
            return new WinBattleMessage(ownerId, p);
        }

		#endregion Overriden

		#region Constructor

        public WinBattleMessage() { }

		public WinBattleMessage( int ownerId, params object[] p )
			: base(ownerId, p) {
			log = "You won a battle and gain {0} points. Check it <a href='/Battle/Battle.aspx?id={1}'>here</a>.";
		}

		#endregion Constructor

        
    }
}
