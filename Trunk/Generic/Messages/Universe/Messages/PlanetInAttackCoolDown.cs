using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlanetInAttackCoolDown")]
	public class PlanetInAttackCoolDown : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PlanetInAttackCoolDown(ownerid, msgParameters);
		}


		#endregion Overriden

		#region Constructor

		public PlanetInAttackCoolDown() {}

        public PlanetInAttackCoolDown(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The planet '{0}' cannot be attacked because it's on an attack cooldown.";
		}

		#endregion Constructor
	}
}
