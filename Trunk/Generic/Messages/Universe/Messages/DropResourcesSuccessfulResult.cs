using DesignPatterns.Attributes;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Generic.Messages {

    /// <summary>
    /// DropResourcesSuccessfulResult result
    /// </summary>
	[FactoryKey("DropResourcesSuccessfulResult")]
	public class DropResourcesSuccessfulResult : UniverseMessage {

		#region Properties

		public override MessageType MessageType {
			get { return MessageType.Resources; }
		}

		#endregion Properties

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
			return new DropResourcesSuccessfulResult(ownerid, msgParameters);
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

		#region Constructor

		public DropResourcesSuccessfulResult() { }

		public DropResourcesSuccessfulResult(int ownerId, params object[] p)
			: base(ownerId, p) {
			log = "{0} units of the resource '{1}' were drop successfully.";
		}

		#endregion Constructor

    };
}
