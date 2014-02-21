using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("StolenResourcesMessage")]
	public class StolenResourcesMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new StolenResourcesMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public StolenResourcesMessage() { }

		public StolenResourcesMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You have stolen the following resources of the player '{0}': {1}.";
		}

		#endregion Constructor
	}
}
