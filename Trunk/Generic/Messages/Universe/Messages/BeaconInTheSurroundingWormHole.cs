using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BeaconInTheSurroundingWormHole")]
	public class BeaconInTheSurroundingWormHole : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Beacon; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new BeaconInTheSurroundingWormHole(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public BeaconInTheSurroundingWormHole() { }

		public BeaconInTheSurroundingWormHole(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "WormHole could not be created. A Beacon is in the area that avoids its creation.";
		}

		#endregion Constructor
	}
}
