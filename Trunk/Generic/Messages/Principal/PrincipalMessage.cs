using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class PrincipalMessage: UniverseMessage {

		#region Properties

		public override Category Category {
            get { return Category.Principal; }
		}

		#endregion Properties

		#region Constructor

        public PrincipalMessage() { }

		public PrincipalMessage(int ownerId, params object[] p) :
            base(ownerId,p) {
		}

		#endregion Constructor
	}

}
