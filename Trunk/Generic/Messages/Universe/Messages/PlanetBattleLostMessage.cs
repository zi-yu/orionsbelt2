using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlanetBattleLostMessage")]
	public class PlanetBattleLostMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PlanetBattleLostMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public PlanetBattleLostMessage() { }

		public PlanetBattleLostMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Battle at planet '{0}' was lost.";
		}

		#endregion Constructor
	}
}
