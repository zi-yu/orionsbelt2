using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlayerIsToWeakMessage")]
	public class PlayerIsToWeakMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Battle; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new PlayerIsToWeakMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public PlayerIsToWeakMessage() { }

		public PlayerIsToWeakMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Player '{0}' is to weak to be attacked. You can only attack player with level '{1}' or above.";
		}

		#endregion Constructor
	}
}
