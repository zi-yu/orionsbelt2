using DesignPatterns.Attributes;
using System;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PrincipalNewGameMedalMessage")]
    public class PrincipalNewGameMedalMessage : PlayerMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PrincipalNewGameMedalMessage(ownerid, msgParameters);
		}

        public override Category Category {
            get {
                return Category.Principal;
            }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Good; }
        }

        public override string Translate() {
			try{
                string token = languageTranslator.Translate(SubCategory);
				return string.Format(token, languageTranslator.Translate(Parameters[0]));
			}catch(FormatException) {
				throw new OrionsBeltException("Invalid format at Message '{0}'. Parameter count: {1}", SubCategory, Parameters.Count);
			}
		}

		#endregion Overriden

		#region Constructor

		public PrincipalNewGameMedalMessage() {}

        public PrincipalNewGameMedalMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
