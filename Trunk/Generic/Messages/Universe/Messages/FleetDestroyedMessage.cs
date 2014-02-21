using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetDestroyedMessage")]
	public class FleetDestroyedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetDestroyedMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public FleetDestroyedMessage() { }

		public FleetDestroyedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' was destroyed in battle.";
		}

		#endregion Constructor
	}
}
