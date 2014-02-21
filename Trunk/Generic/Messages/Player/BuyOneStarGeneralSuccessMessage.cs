using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BuyOneStarGeneralSuccessMessage")]
    public class BuyOneStarGeneralSuccessMessage : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyOneStarGeneralSuccessMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

		#endregion Overriden

		#region Constructor

		public BuyOneStarGeneralSuccessMessage() {}

		public BuyOneStarGeneralSuccessMessage(int ownerId)
			: base(ownerId) {
			log = "You now have a One Star General at your disposal.";
		}

		#endregion Constructor
	}
}
