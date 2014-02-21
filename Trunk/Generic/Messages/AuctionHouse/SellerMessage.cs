using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("SellerMessage")]
    public class SellerMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new SellerMessage(ownerid);
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

		public SellerMessage() {}

        public SellerMessage(int ownerId)
			: base(ownerId) {
			log = "Product sold";
		}

		#endregion Constructor
	}
}
