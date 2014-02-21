using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("PlanetInConquerCoolDown")]
	public class PlanetInConquerCoolDown : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PlanetInConquerCoolDown(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

        public PlanetInConquerCoolDown() { }

        public PlanetInConquerCoolDown(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The planet '{0}' cannot be conquered because it's on an conquer cooldown.";
		}

		#endregion Constructor
	}
}
