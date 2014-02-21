using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceCreatedMessage")]
	public class AllianceCreatedMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceCreatedMessage();
		}

		#endregion Overriden

    };
}
