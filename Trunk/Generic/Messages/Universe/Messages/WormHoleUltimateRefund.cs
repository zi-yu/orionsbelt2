using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("WormHoleUltimateRefund")]
	public class WormHoleUltimateRefund : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.BugWormHole; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new WormHoleUltimateRefund(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public WormHoleUltimateRefund() { }

        public WormHoleUltimateRefund(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "WormHole could not be created. Resources were returned.";
		}

		#endregion Constructor
	}
}
