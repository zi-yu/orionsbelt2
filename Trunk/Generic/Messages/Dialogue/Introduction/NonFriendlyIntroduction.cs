using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("NonFriendlyIntroduction")]
    public class NonFriendlyIntroduction : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new NonFriendlyIntroduction(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Introduction; }
        }

		#endregion Overriden

		#region Constructor

		public NonFriendlyIntroduction() {}

        public NonFriendlyIntroduction(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
