using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class AllianceMessage: MessageBase {

		#region Properties

		public override Category Category {
			get { return Category.Alliance; }
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
	
    };

}
