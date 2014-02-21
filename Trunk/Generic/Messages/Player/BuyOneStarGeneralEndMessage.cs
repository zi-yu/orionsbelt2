using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyOneStarGeneralEndMessage")]
    public class BuyOneStarGeneralEndMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyOneStarGeneralEndMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyOneStarGeneralEndMessage() {}

		public BuyOneStarGeneralEndMessage(int ownerId)
			: base(ownerId) {
			log = "The contract with the One Star General has expired. Go to the shop in order to renew the contract.";
		}

		#endregion Constructor
	}
}
