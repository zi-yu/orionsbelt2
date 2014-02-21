using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("YouHaveATargetOnYourHead")]
    public class YouHaveATargetOnYourHead : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new YouHaveATargetOnYourHead(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Hostile; }
        }

		#endregion Overriden

		#region Constructor

		public YouHaveATargetOnYourHead() {}

        public YouHaveATargetOnYourHead(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
