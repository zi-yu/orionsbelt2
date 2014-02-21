using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyFastSpeedEndMessage")]
    public class BuyFastSpeedEndMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyFastSpeedEndMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyFastSpeedEndMessage() {}

        public BuyFastSpeedEndMessage(int ownerId)
			: base(ownerId) {
			log = "Welcome to the game.";
		}

		#endregion Constructor
	}
}
