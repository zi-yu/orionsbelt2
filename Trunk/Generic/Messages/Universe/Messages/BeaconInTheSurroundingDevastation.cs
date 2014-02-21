using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("BeaconInTheSurroundingDevastation")]
	public class BeaconInTheSurroundingDevastation : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Beacon; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new BeaconInTheSurroundingDevastation(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public BeaconInTheSurroundingDevastation() { }

		public BeaconInTheSurroundingDevastation(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Devastation could not be fired. A Beacon is in the area that avoids its usage.";
		}

		#endregion Constructor
	}
}
