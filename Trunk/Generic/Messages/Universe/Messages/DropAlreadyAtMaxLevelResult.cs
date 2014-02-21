using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Generic.Messages {

    /// <summary>
    /// AlreadyAtMaxLevelResult result
    /// </summary>
	[FactoryKey("DropAlreadyAtMaxLevelResult")]
	public class DropAlreadyAtMaxLevelResult : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DropAlreadyAtMaxLevelResult(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

		#region Constructor

		public DropAlreadyAtMaxLevelResult() { }

		public DropAlreadyAtMaxLevelResult(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "Could not drop resource {0} because it's already at max level.";
		}

		#endregion Constructor


    };
}
