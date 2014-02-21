using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class PlayerMessage: UniverseMessage {

		#region Properties

		public override Category Category {
			get { return Category.Player; }
		}

		#endregion Properties

		#region Constructor

		public PlayerMessage() {}

		public PlayerMessage(int ownerId, params object[] p) :
            base( ownerId,p) {
                
		}

		#endregion Constructor
	}

}
