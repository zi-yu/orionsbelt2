using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("RelicIncomeReceived")]
    public class RelicIncomeReceived : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new RelicIncomeReceived(ownerid, msgParameters);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public RelicIncomeReceived() {}

        public RelicIncomeReceived(int ownerId, params object[] msgParameters)
			: base(ownerId, msgParameters) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
