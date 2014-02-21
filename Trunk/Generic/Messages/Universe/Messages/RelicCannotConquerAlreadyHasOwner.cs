using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicCannotConquerAlreadyHasOwner")]
	public class RelicCannotConquerAlreadyHasOwner : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicCannotConquerAlreadyHasOwner(ownerid, msgParameters);
		}

		#endregion Overriden

		#region Constructor

		public RelicCannotConquerAlreadyHasOwner() { }

		public RelicCannotConquerAlreadyHasOwner(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Relic at coordinate '{0}' cannot be conquered because it already has an owner.";
		}

		#endregion Constructor
	}
}
