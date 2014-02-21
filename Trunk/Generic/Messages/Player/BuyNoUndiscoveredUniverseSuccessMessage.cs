using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyNoUndiscoveredUniverseSuccessMessage")]
    public class BuyNoUndiscoveredUniverseSuccessMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyNoUndiscoveredUniverseSuccessMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyNoUndiscoveredUniverseSuccessMessage() {}

        public BuyNoUndiscoveredUniverseSuccessMessage(int ownerId)
			: base(ownerId) {
			log = "Welcome to the game.";
		}

		#endregion Constructor
	}
}
