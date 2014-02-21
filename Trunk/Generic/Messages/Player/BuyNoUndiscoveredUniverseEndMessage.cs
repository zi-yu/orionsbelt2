using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyNoUndiscoveredUniverseEndMessage")]
    public class BuyNoUndiscoveredUniverseEndMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyNoUndiscoveredUniverseEndMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyNoUndiscoveredUniverseEndMessage() {}

        public BuyNoUndiscoveredUniverseEndMessage(int ownerId)
			: base(ownerId) {
			log = "Welcome to the game.";
		}

		#endregion Constructor
	}
}
