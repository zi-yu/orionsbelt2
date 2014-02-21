using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("YouAbandom")]
    public class YouAbandom : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new YouAbandom(ownerid);
		}

        public override Category Category  {
            get { return Category.Principal; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Information; }
        }

        public override string Translate()
        {
            string param1 = Parameters[0];

            return string.Format(LanguageTranslator.Translate(SubCategory), param1);
        }

		#endregion Overriden

		#region Constructor

		public YouAbandom() {}

        public YouAbandom(int ownerId)
			: base(ownerId) {
			log = "You abandom team";
		}

		#endregion Constructor
	}
}
