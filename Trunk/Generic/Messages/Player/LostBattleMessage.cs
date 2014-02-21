using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("LostBattleMessage")]
	public class LostBattleMessage : PlayerMessage {
		
		#region Overriden

        protected override IMessage CreateMessage(int ownerId, params object[] p){
            return new LostBattleMessage(ownerId, p);
        }

		#endregion Overriden

		#region Constructor

        public LostBattleMessage() { }

        public LostBattleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You lost a battle and lost {0} points. Check it <a href='/Battle/Battle.aspx?id={1}'>here</a>.";
		}

		#endregion Constructor

        
    }
}
