using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("LeaveMeAlone")]
    public class LeaveMeAlone : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new LeaveMeAlone(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Generic; }
        }

		#endregion Overriden

		#region Constructor

		public LeaveMeAlone() {}

        public LeaveMeAlone(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
