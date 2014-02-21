using DesignPatterns.Attributes;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("CatchResourcesMessage")]
	public class CatchResourcesMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new CatchResourcesMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance {
            get {
                return MessageImportance.Good;
            }
        }

        public override string Translate()
        {
            return string.Format(languageTranslator.Translate(SubCategory), Parameters[0], languageTranslator.Translate(Parameters[1]));
        }

		#endregion Overriden

		#region Constructor

		public CatchResourcesMessage() { }

		public CatchResourcesMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "You caught {0} units of {1}.";
		}

		#endregion Constructor

	};
}
