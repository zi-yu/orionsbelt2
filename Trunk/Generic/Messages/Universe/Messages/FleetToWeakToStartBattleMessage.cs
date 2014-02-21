using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("FleetToWeakToStartBattleMessage")]
	public class FleetToWeakToStartBattleMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Fleet; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new FleetToWeakToStartBattleMessage(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public FleetToWeakToStartBattleMessage() { }

		public FleetToWeakToStartBattleMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' is to weak to start a battle and was destroyed by the player '{1}'.";
		}

		#endregion Constructor
	}
}
