using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("LostPrincipalBattleMessage")]
	public class LostPrincipalBattleMessage : PrincipalMessage {
		
		#region Overriden

        protected override IMessage CreateMessage(int ownerId, params object[] p){
            return new LostPrincipalBattleMessage(ownerId, p);
        }

		#endregion Overriden

		#region Constructor

        public LostPrincipalBattleMessage() { }

        public LostPrincipalBattleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You lost a battle. Check it <a href='/Battle/Battle.aspx?id={0}'>here</a>.";
		}

		#endregion Constructor

        
    }
}
