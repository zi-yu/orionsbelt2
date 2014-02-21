using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("DeployTimeoutMessage")]
	public class DeployTimeoutMessage : BattleMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new DeployTimeoutMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public DeployTimeoutMessage() { }

		public DeployTimeoutMessage(int ownerId, int battleTurn, params object[] p)
			: base(ownerId, battleTurn, p) {
			log = "Player '{0}' gave a deploy timeout.";
		}

		#endregion Constructor
	}
}
