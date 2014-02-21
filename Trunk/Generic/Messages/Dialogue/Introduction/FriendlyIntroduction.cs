using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FriendlyIntroduction")]
    public class FriendlyIntroduction : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new FriendlyIntroduction(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Introduction; }
        }

		#endregion Overriden

		#region Constructor

		public FriendlyIntroduction() {}

        public FriendlyIntroduction(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
