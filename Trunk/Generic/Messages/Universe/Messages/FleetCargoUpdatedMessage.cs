using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetCargoUpdatedMessage")]
	public class FleetCargoUpdatedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetCargoUpdatedMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		public override MessageImportance Importance {
			get {
				return MessageImportance.Good;
			}
		}

		#region Constructor

		public FleetCargoUpdatedMessage() { }

		public FleetCargoUpdatedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cargo of the fleet '{0}' was updated.";
		}

		#endregion Constructor
	}
}
