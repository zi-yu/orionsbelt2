using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("PrizeMessage")]
    public class PrizeMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PrizeMessage(ownerid);
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

		public PrizeMessage() {}

        public PrizeMessage(int ownerId)
			: base(ownerId) {
			log = "Prize message";
		}

		#endregion Constructor
	}
}
