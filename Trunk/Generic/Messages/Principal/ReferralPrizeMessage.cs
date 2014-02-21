using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("ReferralPrizeMessage")]
    public class ReferralPrizeMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new ReferralPrizeMessage(ownerid);
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

		public ReferralPrizeMessage() {}

        public ReferralPrizeMessage(int ownerId)
			: base(ownerId) {
                log = "Referral Prize Message";
		}

		#endregion Constructor
	}
}
