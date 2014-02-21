using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicConqueredMessage")]
	public class RelicConqueredMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicConqueredMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public RelicConqueredMessage() { }

		public RelicConqueredMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You conquered a relic at coordinate '{0}'.";
		}

		#endregion Constructor
	}
}
