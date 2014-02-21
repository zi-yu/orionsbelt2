using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AlreadyAtPlanetLimitMessage")]
	public class AlreadyAtPlanetLimitMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get {return MessageType.Planet;}
		}
		
		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new AlreadyAtPlanetLimitMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public AlreadyAtPlanetLimitMessage() { }

        public AlreadyAtPlanetLimitMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Player '{0}' can't get another planet because it's already at full limit!";
		}

		#endregion Constructor
	}
}
