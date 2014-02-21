using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("WinPrincipalBattleMessage")]
	public class WinPrincipalBattleMessage : PrincipalMessage {
		
		#region Overriden

        protected override IMessage CreateMessage(int ownerId, params object[] p){
            return new WinPrincipalBattleMessage(ownerId, p);
        }

		#endregion Overriden

		#region Constructor

        public WinPrincipalBattleMessage() { }

        public WinPrincipalBattleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You won a battle. Check it <a href='/Battle/Battle.aspx?id={0}'>here</a>.";
		}

		#endregion Constructor

        
    }
}
