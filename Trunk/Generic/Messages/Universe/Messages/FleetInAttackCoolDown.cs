using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("FleetInAttackCoolDown")]
	public class FleetInAttackCoolDown : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new FleetInAttackCoolDown(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public FleetInAttackCoolDown() { }

        public FleetInAttackCoolDown(int ownerId, params object[] p)
			: base(ownerId, p) {
            log = "The fleet '{0}' cannot be attacked because it's on an attack immunity.";
		}

		#endregion Constructor
	}
}
