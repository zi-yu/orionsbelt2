using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("OverbidMessage")]
    public class OverbidMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new OverbidMessage(ownerid);
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

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2);
        }

		#endregion Overriden

		#region Constructor

		public OverbidMessage() {}

        public OverbidMessage(int ownerId)
			: base(ownerId) {
			log = "Overbid message";
		}

		#endregion Constructor
	}
}
