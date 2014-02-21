using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BidBuyoutMessage")]
    public class BidBuyoutMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BidBuyoutMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.AuctionHouse; }
        }

        public override string Translate()
        {
            string param1 = Parameters[0];
            string param2 = LanguageTranslator.Translate(Parameters[1]);
            string param3 = Parameters[2];

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2, param3);
        }

		#endregion Overriden

		#region Constructor

		public BidBuyoutMessage() {}

        public BidBuyoutMessage(int ownerId)
			: base(ownerId) {
			log = "Product buyed";
		}

		#endregion Constructor
	}
}
