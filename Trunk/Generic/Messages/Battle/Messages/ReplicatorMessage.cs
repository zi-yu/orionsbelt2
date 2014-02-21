using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("ReplicatorMessage")]
	public class ReplicatorMessage : BattleMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, int battleTurn, params object[] msgParameters ) {
			return new ReplicatorMessage(ownerid, battleTurn, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public ReplicatorMessage() {}

		public ReplicatorMessage( int ownerId, int battleTurn, params object[] p )
			: base(ownerId, battleTurn, p) {
			log = "Replicator attack made the unit {0} replicate {1} times.";
		}

		#endregion Constructor
	}
}
