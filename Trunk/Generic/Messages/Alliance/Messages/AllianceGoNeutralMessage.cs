using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceGoNeutralMessage")]
	public class AllianceGoNeutralMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceGoNeutralMessage();
		}

		#endregion Overriden

    };
}
