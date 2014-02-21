using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("DevastationAttackDestroyFleet")]
	public class DevastationAttackDestroyFleet : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Devastation; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DevastationAttackDestroyFleet(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public DevastationAttackDestroyFleet() { }

		public DevastationAttackDestroyFleet(int ownerId, params object[] p)
			: base(ownerId, p) {
                log = "All units in the fleet '{0}' ({2}) ({1} total) were destroyed by a devastation attack .";
		}

		#endregion Constructor
	}
}
