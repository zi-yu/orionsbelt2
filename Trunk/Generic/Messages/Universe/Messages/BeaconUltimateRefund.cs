using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("BeaconUltimateRefund")]
	public class BeaconUltimateRefund : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Beacon; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new BeaconUltimateRefund(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public BeaconUltimateRefund() { }

        public BeaconUltimateRefund(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Beacon could not be created. Resources were returned.";
		}

		#endregion Constructor
	}
}
