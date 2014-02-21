using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class UniverseMessage: MessageBase {

		#region Properties

		public override Category Category {
			get { return Category.Universe; }
		}

		#endregion Properties

		#region Properties

		public override object create( object args ) {
			Message arguments = (Message) args;

			int ownerid = arguments.OwnerId;
			string[] s = arguments.Parameters.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			return CreateMessage(ownerid, s);
		}

		#endregion Properties

		#region Abstract

		protected abstract IMessage CreateMessage(int ownerId, params object[] p);

        protected virtual IMessage CreateMessage()
        {
            return CreateMessage(0, null);
        }

		#endregion Abstract

		#region Constructor

		public UniverseMessage() {}

		public UniverseMessage(int ownerId, params object[] p) {
			date = DateTime.Now;
			this.ownerId = ownerId;
			
			foreach (object s in p) {
				parameters.Add(s.ToString());
			}
		}

		#endregion Constructor
	}

}
