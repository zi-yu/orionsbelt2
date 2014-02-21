using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("UltimateWeaponNotReady")]
	public class UltimateWeaponNotReady : UniverseMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new UltimateWeaponNotReady(ownerid);
		}

        public override MessageImportance Importance {
            get {
                return MessageImportance.Good;
            }
        }

		#endregion Overriden

		#region Constructor

		public UltimateWeaponNotReady() { }

        public UltimateWeaponNotReady(int ownerId)
            : base(ownerId, new object[] { })
        {
            log = "Ultimate weapon is not ready. Please verify if you have enough resources.";
        }

		#endregion Constructor
	}
}
