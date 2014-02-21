using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("RelicInConquerCoolDown")]
	public class RelicInConquerCoolDown : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new RelicInConquerCoolDown(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

        public RelicInConquerCoolDown() { }

        public RelicInConquerCoolDown(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The relic at coordinate '{0}' cannot be conquered because it's on an conquer cooldown.";
		}

		#endregion Constructor
	}
}
