using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("NotGonnaHappen")]
    public class NotGonnaHappen : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new NotGonnaHappen(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Generic; }
        }

		#endregion Overriden

		#region Constructor

		public NotGonnaHappen() {}

        public NotGonnaHappen(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
