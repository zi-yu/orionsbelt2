using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BountyRewardWonMessage")]
    public class BountyRewardWonMessage : UniverseMessage
    {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BountyRewardWonMessage(ownerid);
		}

        public override Category Category  {
            get { return Category.Principal; }
        }

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public BountyRewardWonMessage() {}

        public BountyRewardWonMessage(int ownerId, params object[] msgParameters)
			: base(ownerId, msgParameters) {
			log = "Vacations Auto Started.";
		}

		#endregion Constructor
	}
}
