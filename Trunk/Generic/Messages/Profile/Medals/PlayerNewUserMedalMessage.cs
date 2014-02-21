using DesignPatterns.Attributes;
using System;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("PlayerNewUserMedalMessage")]
    public class PlayerNewUserMedalMessage : PlayerMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new PlayerNewUserMedalMessage(ownerid, msgParameters);
		}

        public override Category Category {
            get {
                return Category.Player;
            }
        }

        public override MessageImportance  Importance {
            get { return MessageImportance.Good; }
        }

        public override string Translate() {
			try{
                string token = languageTranslator.Translate(SubCategory);
				return string.Format(token, languageTranslator.Translate(Parameters[0]), Parameters[1]);
			}catch(FormatException) {
				throw new OrionsBeltException("Invalid format at Message '{0}'. Parameter count: {1}", SubCategory, Parameters.Count);
			}
		}

		#endregion Overriden

		#region Constructor

		public PlayerNewUserMedalMessage() {}

        public PlayerNewUserMedalMessage(int targetId, params object[] msgParameters)
            : base(targetId, msgParameters)
        {
			log = "Good Game!";
		}

		#endregion Constructor
	};
}
