using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BountyCollectedOnYouMessage")]
    public class BountyCollectedOnYouMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BountyCollectedOnYouMessage(ownerid, msgParameters);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public BountyCollectedOnYouMessage() {}

        public BountyCollectedOnYouMessage(int ownerId, params object[] msgParameters)
			: base(ownerId, msgParameters) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
