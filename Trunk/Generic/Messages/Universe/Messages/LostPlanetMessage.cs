using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("LostPlanetMessage")]
	public class LostPlanetMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new LostPlanetMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public LostPlanetMessage() {}

		public LostPlanetMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Planet at coordinate {0} was lost in battle.";
		}

		#endregion Constructor
	}
}
