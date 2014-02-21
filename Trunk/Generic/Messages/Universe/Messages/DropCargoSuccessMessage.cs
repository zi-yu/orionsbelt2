using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Generic.Messages {

    /// <summary>
    /// DropResourcesSuccessfulResult result
    /// </summary>
	[FactoryKey("DropCargoSuccessMessage")]
	public class DropCargoSuccessMessage : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DropCargoSuccessMessage(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public DropCargoSuccessMessage() { }

		public DropCargoSuccessMessage(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "All the cargo was dropped with success.";
		}

		#endregion Constructor

    };
}
