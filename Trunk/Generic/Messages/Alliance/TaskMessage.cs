using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class TaskMessage: MessageBase {

		#region Properties

		public override Category Category {
			get { return Category.Task; }
		}

		#endregion Properties

		#region Base Implementation

		public override object create( object args ) 
        {
			Message arguments = (Message) args;
			return CreateMessage(arguments);
        }

        #endregion Base Implementation

        #region Abstract

        protected abstract IMessage CreateMessage(Message arguments);

		#endregion Abstract
	
        public TaskMessage()
        {
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromHours(6)));
        }
    };

}
