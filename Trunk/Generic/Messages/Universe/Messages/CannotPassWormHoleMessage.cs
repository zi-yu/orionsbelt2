using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CannotPassWormHoleMessage")]
	public class CannotPassWormHoleMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new CannotPassWormHoleMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

        public CannotPassWormHoleMessage() { }

		public CannotPassWormHoleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' cannot pass in the wormhole because it has trade goods that prevent it.";
		}

		#endregion Constructor
	}
}
