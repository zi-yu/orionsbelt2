using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("UnloadTrades")]
    public class UnloadTrades : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new UnloadTrades(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Information; }
        }

		#endregion Overriden

		#region Constructor

		public UnloadTrades() {}

        public UnloadTrades(int ownerId)
			: base(ownerId) {
                log = "UnloadTrades trades";
		}

		#endregion Constructor
	}
}
