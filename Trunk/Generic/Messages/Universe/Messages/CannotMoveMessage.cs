using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CannotMoveMessage")]
	public class CannotMoveMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new CannotMoveMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance {
            get {
                return MessageImportance.Bad;
            }
        }

        #endregion Overriden

		#region Constructor

		public CannotMoveMessage() { }

		public CannotMoveMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' is stuck. Please find an alternative path or clear the path using a battle. If you don't want to battle, try to send other fleets to get a movable spot.";
		}

		#endregion Constructor

	};
}
