using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("DevastationAttackResult")]
	public class DevastationAttackResult : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Devastation; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DevastationAttackResult(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public DevastationAttackResult() { }

		public DevastationAttackResult(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The Devastation attack was fired in coordinate '{0}'. The attack destroyed a total of {1} units!";
		}

		#endregion Constructor
	}
}
