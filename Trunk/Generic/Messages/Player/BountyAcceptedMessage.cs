using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BountyAcceptedMessage")]
    public class BountyAcceptedMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BountyAcceptedMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Player; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public BountyAcceptedMessage() {}

        public BountyAcceptedMessage(int ownerId, params object[] msgParameters)
			: base(ownerId, msgParameters) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
