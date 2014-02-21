using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages
{

    [FactoryKey("DonationMessage")]
    public class DonationMessage : TaskMessage
    {

        #region Overriden

        protected override IMessage CreateMessage(Message message)
        {
            return new DonationMessage();
        }

        public DonationMessage()
        {
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromHours(12)));
        }

        #endregion Overriden

    };

}
