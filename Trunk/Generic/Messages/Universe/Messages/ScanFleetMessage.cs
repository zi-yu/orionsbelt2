using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("ScanFleetMessage")]
    public class ScanFleetMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new ScanFleetMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

        public override string Translate()
        {
            return string.Format(LanguageTranslator.Translate(SubCategory));
        }

		#endregion Overriden

		#region Constructor

		public ScanFleetMessage() {}

        public ScanFleetMessage(int ownerId)
			: base(ownerId) {
                log = "Scan Fleet message";
		}

		#endregion Constructor
	}
}
