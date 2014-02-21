using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BetterLuckNextTime")]
    public class BetterLuckNextTime : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BetterLuckNextTime(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.AfterBattle; }
        }

		#endregion Overriden

		#region Constructor

		public BetterLuckNextTime() {}

        public BetterLuckNextTime(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
