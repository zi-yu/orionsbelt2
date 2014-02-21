using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BonusCodeMessage")]
    public class BonusCodeMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BonusCodeMessage(ownerid);
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

		public BonusCodeMessage() {}

        public BonusCodeMessage(int ownerId)
			: base(ownerId) {
                log = "Bonus Code Message";
		}

		#endregion Constructor
	}
}
