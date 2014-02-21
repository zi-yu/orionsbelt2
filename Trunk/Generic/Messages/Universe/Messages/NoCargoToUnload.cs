using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("NoCargoToUnload")]
	public class NoCargoToUnload : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new NoCargoToUnload(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public NoCargoToUnload() {}

		public NoCargoToUnload(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' has no cargo to unload.";
		}

		#endregion Constructor
	}
}
