using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("AllianceEndWarMessage")]
	public class AllianceEndWarMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new AllianceEndWarMessage();
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Good; }
        }

		#endregion Overriden

    };
}
