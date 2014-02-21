using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("NewWormHoleFoundMessage")]
	public class NewWormHoleFoundMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.WormHole; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new NewWormHoleFoundMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public NewWormHoleFoundMessage() {}

		public NewWormHoleFoundMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You found a new Wormhole at coordinate '{0}'. The new wormhole was added to your list of known wormholes.";
		}

		#endregion Constructor
	}
}
