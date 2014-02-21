using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("TeamAbandom")]
    public class TeamAbandom : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new TeamAbandom(ownerid);
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

		public TeamAbandom() {}

        public TeamAbandom(int ownerId)
			: base(ownerId) {
			log = "Team abandom";
		}

		#endregion Constructor
	}
}
