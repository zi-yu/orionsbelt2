using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceNewNAPMessage")]
	public class AllianceNewNAPMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceNewNAPMessage();
		}

		#endregion Overriden

    };
}
