using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("NecessityCreatedMessage")]
    public class NecessityCreatedMessage : TaskMessage
    {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new NecessityCreatedMessage();
		}

		#endregion Overriden

    };
}
