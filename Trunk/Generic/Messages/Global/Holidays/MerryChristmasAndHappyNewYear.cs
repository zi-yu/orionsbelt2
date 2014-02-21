using DesignPatterns.Attributes;
using System;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("MerryChristmasAndHappyNewYear")]
    public class MerryChristmasAndHappyNewYear : GlobalMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new MerryChristmasAndHappyNewYear();
		}

		#endregion Overriden

		#region Constructor

        public MerryChristmasAndHappyNewYear()
        {
            log = "MerryChristmasAndHappyNewYear";
            TickDeadline = Clock.Instance.EndTickByDelay( Clock.Instance.ConvertToTicks(TimeSpan.FromDays(10)));
		}

		#endregion Constructor

	};
}
