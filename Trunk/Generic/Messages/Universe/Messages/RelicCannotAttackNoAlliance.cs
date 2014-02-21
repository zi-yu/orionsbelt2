using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicCannotAttackNoAlliance")]
	public class RelicCannotAttackNoAlliance : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicCannotAttackNoAlliance(ownerid, msgParameters);
		}

        #endregion Overriden

		#region Constructor

		public RelicCannotAttackNoAlliance() { }

		public RelicCannotAttackNoAlliance(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cannot attack Relic at coordinate '{0}' because you're not in a Alliance.";
		}

		#endregion Constructor

	};
}
