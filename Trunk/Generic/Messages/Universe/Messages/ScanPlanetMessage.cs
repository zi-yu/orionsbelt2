using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("ScanPlanetMessage")]
    public class ScanPlanetMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new ScanPlanetMessage(ownerid);
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

		public ScanPlanetMessage() {}

        public ScanPlanetMessage(int ownerId)
			: base(ownerId) {
                log = "Scan Planet message";
		}

		#endregion Constructor
	}
}
