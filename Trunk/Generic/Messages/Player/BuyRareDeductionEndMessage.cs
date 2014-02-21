using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyRareDeductionEndMessage")]
    public class BuyRareDeductionEndMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyRareDeductionEndMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyRareDeductionEndMessage() {}

        public BuyRareDeductionEndMessage(int ownerId)
			: base(ownerId) {
			log = "Welcome to the game.";
		}

		#endregion Constructor
	}
}
