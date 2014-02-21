using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("MaximumFleets")]
	public class MaximumFleets : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Universe; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new MaximumFleets(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

        public MaximumFleets() { }

		public MaximumFleets(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Maximum Fleets.";
		}

		#endregion Constructor
	}
}
