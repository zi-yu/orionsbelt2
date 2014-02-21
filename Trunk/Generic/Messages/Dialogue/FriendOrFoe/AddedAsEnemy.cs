using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("AddedAsEnemyMessage")]
    public class AddedAsEnemyMessage : DialogueMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new AddedAsEnemyMessage(ownerid, msgParameters);
		}

        public override DialogueMessageType DialogueType {
            get { return DialogueMessageType.Generic; }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public AddedAsEnemyMessage() {}

        public AddedAsEnemyMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
