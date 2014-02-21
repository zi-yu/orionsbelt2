using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetWonMessage")]
	public class FleetWonMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetWonMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public FleetWonMessage() { }

		public FleetWonMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' won the battle.";
		}

		#endregion Constructor
	}
}
