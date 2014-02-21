using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("DevastationCannotBeUsed")]
	public class DevastationCannotBeUsed : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Devastation; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DevastationCannotBeUsed(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public DevastationCannotBeUsed() { }

		public DevastationCannotBeUsed(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Devastation Cannot be used because you don't have enough resources.";
		}

		#endregion Constructor
	}
}
