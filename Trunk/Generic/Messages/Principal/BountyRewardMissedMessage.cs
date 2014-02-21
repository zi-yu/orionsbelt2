using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BountyRewardMissedMessage")]
    public class BountyRewardMissedMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BountyRewardMissedMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Principal; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public BountyRewardMissedMessage() {}

        public BountyRewardMissedMessage(int ownerId, params object[] msgParameters)
			: base(ownerId, msgParameters) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
