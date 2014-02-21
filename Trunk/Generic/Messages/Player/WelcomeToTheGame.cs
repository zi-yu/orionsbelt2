using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("WelcomeToTheGame")]
    public class WelcomeToTheGame : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new WelcomeToTheGame(ownerid);
		}

        public override Category Category  {
            get { return Category.Universe; }
        }

		#endregion Overriden

		#region Constructor

		public WelcomeToTheGame() {}

        public WelcomeToTheGame(int ownerId)
			: base(ownerId) {
			log = "Welcome to the game.";
		}

		#endregion Constructor
	}
}
