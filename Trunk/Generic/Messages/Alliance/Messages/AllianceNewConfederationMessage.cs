using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceNewConfederationMessage")]
	public class AllianceNewConfederationMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceNewConfederationMessage();
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

    };
}
