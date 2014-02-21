using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PrincipalNewUserMedalMessage")]
    public class PrincipalNewUserMedalMessage : PlayerMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PrincipalNewUserMedalMessage(ownerid, msgParameters);
		}

        public override Category Category {
            get {
                return Category.Principal;
            }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public PrincipalNewUserMedalMessage() {}

        public PrincipalNewUserMedalMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
