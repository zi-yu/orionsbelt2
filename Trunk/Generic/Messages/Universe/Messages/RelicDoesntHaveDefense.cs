using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("RelicDoesntHaveDefense")]
	public class RelicDoesntHaveDefense : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Relic; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new RelicDoesntHaveDefense(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public RelicDoesntHaveDefense() { }

		public RelicDoesntHaveDefense(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Fleet '{0}' didn't found any defense in relic in coordinate '{1}'.";
		}

		#endregion Constructor
	}
}
