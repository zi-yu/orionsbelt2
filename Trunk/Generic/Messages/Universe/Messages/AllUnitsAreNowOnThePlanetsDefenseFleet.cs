using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllUnitsAreNowOnThePlanetsDefenseFleet")]
	public class AllUnitsAreNowOnThePlanetsDefenseFleet : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new AllUnitsAreNowOnThePlanetsDefenseFleet(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public AllUnitsAreNowOnThePlanetsDefenseFleet() { }

        public AllUnitsAreNowOnThePlanetsDefenseFleet(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Units of the fleet '{0}' are now at the planet '{1}' defense fleet.";
		}

		#endregion Constructor
	}
}
