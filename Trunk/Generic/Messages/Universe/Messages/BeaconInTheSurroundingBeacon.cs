using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BeaconInTheSurroundingBeacon")]
	public class BeaconInTheSurroundingBeacon : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Beacon; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new BeaconInTheSurroundingBeacon(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public BeaconInTheSurroundingBeacon() { }

		public BeaconInTheSurroundingBeacon(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Beacon could not be created. Another Beacon is in the area that avoids its deploy.";
		}

		#endregion Constructor
	}
}
