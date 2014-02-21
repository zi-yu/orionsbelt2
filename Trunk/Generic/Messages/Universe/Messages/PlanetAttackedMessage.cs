using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlanetAttackedMessage")]
	public class PlanetAttackedMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PlanetAttackedMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public PlanetAttackedMessage() { }

		public PlanetAttackedMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Planet '{0}' at coordinate '{1}' was attacked by player '{2}'!";
		}

		#endregion Constructor
	}
}
