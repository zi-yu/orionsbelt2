using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("PromotionMessage")]
    public class PromotionMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PromotionMessage(ownerid);
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
            string param2 = Parameters[1];
            return string.Format(LanguageTranslator.Translate(SubCategory), param1,param2);
        }

		#endregion Overriden

		#region Constructor

		public PromotionMessage() {}

        public PromotionMessage(int ownerId)
			: base(ownerId) {
                log = "Promotion Message";
		}

		#endregion Constructor
	}
}
