using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[FactoryKey("KickPlayerMessage")]
	public class KickPlayerMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new KickPlayerMessage();
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

        #region Ctor

        public KickPlayerMessage()
        {
            log = "Player Kicked";
        }

        #endregion Ctor

    };
}
