using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AssetCreatedMessage")]
    public class AssetCreatedMessage : TaskMessage
    {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AssetCreatedMessage();
		}

        

		#endregion Overriden

    };
}
