using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("LoadTrades")]
    public class LoadTrades : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new LoadTrades(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Information; }
        }

        public override string Translate()
        {
            string param1 = LanguageTranslator.Translate(Parameters[0]);
            string param2 = Parameters[1];
            string param3 = Parameters[2];

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2, param3);
        }

		#endregion Overriden

		#region Constructor

		public LoadTrades() {}

        public LoadTrades(int ownerId)
			: base(ownerId) {
			log = "Load trades";
		}

		#endregion Constructor
	}
}
