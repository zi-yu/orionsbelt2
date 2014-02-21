using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("LeaveAllianceMessage")]
	public class LeaveAllianceMessage : AllianceMessage {
		
		#region Overriden

		protected override IMessage CreateMessage( Message message ) 
        {
            return new LeaveAllianceMessage();
		}

        public override MessageImportance Importance  {
            get { return MessageImportance.Bad; }
        }

		#endregion Overriden

    };
}
