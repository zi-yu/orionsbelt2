using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicCannotConquerNoAlliance")]
	public class RelicCannotConquerNoAlliance : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicCannotConquerNoAlliance(ownerid, msgParameters);
		}

        #endregion Overriden

		#region Constructor

		public RelicCannotConquerNoAlliance() { }

		public RelicCannotConquerNoAlliance(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Cannot conquer the Relic at coordinate '{0}' because you are not in a Alliance.";
		}

		#endregion Constructor

	};
}
