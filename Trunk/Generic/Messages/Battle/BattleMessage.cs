using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class BattleMessage: MessageBase {

		#region Properties

		public override Category Category {
			get { return Category.Battle; }
		}

		#endregion Properties

		#region Properties

		public override object create( object args ) {
			Message arguments = (Message) args;

			int ownerid = arguments.OwnerId;
			int battleTurn = int.Parse(arguments.Extended);

			string[] s = arguments.Parameters.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			return CreateMessage(ownerid, battleTurn, s);
		}

		#endregion Properties

		#region Abstract

		protected abstract IMessage CreateMessage( int ownerid, int battleTurn, params object[] parameters );

		#endregion Abstract

		#region Public

		#endregion

		#region Constructor

		public BattleMessage() {}

		public BattleMessage( int ownerId, int battleTurn, params object[] p ) {
			date = DateTime.Now;
			this.ownerId = ownerId;
			Extended = battleTurn.ToString();

			foreach (object s in p) {
				parameters.Add(s.ToString());
			}
		}

		#endregion Constructor
	}

}
