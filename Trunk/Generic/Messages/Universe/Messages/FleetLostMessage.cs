using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetLostMessage")]
	public class FleetLostMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetLostMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public FleetLostMessage() { }

		public FleetLostMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' lost the battle.";
		}

		#endregion Constructor
	}
}
