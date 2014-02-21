using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class GlobalMessage: UniverseMessage {

		#region Properties

		public override Category Category {
			get { return Category.Global; }
		}

        public override MessageImportance Importance {
            get { return MessageImportance.Normal; }
        }

		#endregion Properties

	};

}
