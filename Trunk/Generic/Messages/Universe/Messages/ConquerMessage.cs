using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("ConquerMessage")]
	public class ConquerMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Planet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new ConquerMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public ConquerMessage() {}

		public ConquerMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You conquered a planet at coordinate '{0}'.";
		}

		#endregion Constructor
	}
}
