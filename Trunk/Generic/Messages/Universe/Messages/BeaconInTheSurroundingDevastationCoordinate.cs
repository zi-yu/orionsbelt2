using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BeaconInTheSurroundingDevastationCoordinate")]
	public class BeaconInTheSurroundingDevastationCoordinate : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Beacon; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new BeaconInTheSurroundingDevastationCoordinate(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public BeaconInTheSurroundingDevastationCoordinate() { }

        public BeaconInTheSurroundingDevastationCoordinate(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Devastation could not be fired at Coordinate {0}. A Beacon is protecting that sector.";
		}

		#endregion Constructor
	}
}
