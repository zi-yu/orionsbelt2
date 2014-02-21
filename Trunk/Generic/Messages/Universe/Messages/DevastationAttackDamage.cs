using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("DevastationAttackDamage")]
	public class DevastationAttackDamage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Devastation; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DevastationAttackDamage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public DevastationAttackDamage() { }

		public DevastationAttackDamage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "The fleet '{0}' ({2}) received damage from a devastation attack and lost a total of {1} units!";
		}

		#endregion Constructor
	}
}
