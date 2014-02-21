using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicInAttackCoolDown")]
	public class RelicInAttackCoolDown : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new RelicInAttackCoolDown(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public RelicInAttackCoolDown() {}

        public RelicInAttackCoolDown(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The relic at coordinate '{0}' cannot be attacked because it's on an attack cooldown.";
		}

		#endregion Constructor
	}
}
