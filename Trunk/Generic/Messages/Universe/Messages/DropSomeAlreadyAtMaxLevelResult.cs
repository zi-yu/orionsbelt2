using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Generic.Messages {

    /// <summary>
	/// DropSomeAlreadyAtMaxLevelResult result
    /// </summary>
	[FactoryKey("DropSomeAlreadyAtMaxLevelResult")]
	public class DropSomeAlreadyAtMaxLevelResult : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DropSomeAlreadyAtMaxLevelResult(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public DropSomeAlreadyAtMaxLevelResult() { }

		public DropSomeAlreadyAtMaxLevelResult(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Only {0} units of the resource '{1}' were drop because it's already at maximum quantity.!";
		}

		#endregion Constructor

    };
}
