using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("TaskCreatedMessage")]
    public class TaskCreatedMessage : TaskMessage
    {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new TaskCreatedMessage();
		}

        

		#endregion Overriden

    };
}
