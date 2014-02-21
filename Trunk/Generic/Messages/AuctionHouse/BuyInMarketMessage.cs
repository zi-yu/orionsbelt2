using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BuyInMarketMessage")]
    public class BuyInMarketMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BuyInMarketMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Information; } 
        }

        public override string Translate()
        {
            string param1 = Parameters[0];
            string param2 = LanguageTranslator.Translate(Parameters[1]);
            string param3 = Parameters[2];
            string param4 = Parameters[3];

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2, param3, param4);
        }

		#endregion Overriden

		#region Constructor

		public BuyInMarketMessage() {}

        public BuyInMarketMessage(int ownerId)
			: base(ownerId) {
			log = "Product buyedin market";
		}

		#endregion Constructor
	}
}
