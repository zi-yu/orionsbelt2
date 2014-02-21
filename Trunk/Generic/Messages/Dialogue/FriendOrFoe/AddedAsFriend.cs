using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AddedAsFriendMessage")]
    public class AddedAsFriendMessage : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new AddedAsFriendMessage(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Generic; }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

        public AddedAsFriendMessage() { }

        public AddedAsFriendMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
