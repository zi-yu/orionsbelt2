using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlanetDoesntHaveDefense")]
	public class PlanetDoesntHaveDefense : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PlanetDoesntHaveDefense(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public PlanetDoesntHaveDefense() { }

		public PlanetDoesntHaveDefense(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' didn't found any defense at planet '{1}'.";
		}

		#endregion Constructor
	}
}
