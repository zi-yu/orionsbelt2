using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("LostAllCargoMessage")]
	public class LostAllCargoMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new LostAllCargoMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public LostAllCargoMessage() { }

		public LostAllCargoMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You lost all the cargo of the fleet '{0}'";
		}

		#endregion Constructor
	}
}
