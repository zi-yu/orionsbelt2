using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("PaymentMessage")]
    public class PaymentMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PaymentMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Principal; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

        public override string Translate()
        {
            string param1 = Parameters[0];

            return string.Format(LanguageTranslator.Translate(SubCategory), param1);
        }

		#endregion Overriden

		#region Constructor

		public PaymentMessage() {}

        public PaymentMessage(int ownerId)
			: base(ownerId) {
                log = "PaymentMessage message";
		}

		#endregion Constructor
	}
}
