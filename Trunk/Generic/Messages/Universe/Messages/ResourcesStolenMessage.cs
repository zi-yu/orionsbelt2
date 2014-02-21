using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("ResourcesStolenMessage")]
	public class ResourcesStolenMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new ResourcesStolenMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public ResourcesStolenMessage() { }

		public ResourcesStolenMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Player '{0}' has stolen you the following resources from planet '{1}'({2}): {3}.";
		}

		#endregion Constructor
	}
}
