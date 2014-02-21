using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlayerNewGameMedalMessage")]
    public class PlayerNewGameMedalMessage : PlayerMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PlayerNewGameMedalMessage(ownerid, msgParameters);
		}

        public override Category Category {
            get {
                return Category.Player;
            }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public PlayerNewGameMedalMessage() {}

        public PlayerNewGameMedalMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
