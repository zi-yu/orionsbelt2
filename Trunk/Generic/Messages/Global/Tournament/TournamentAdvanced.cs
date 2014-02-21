using DesignPatterns.Attributes;
using System;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("TournamentAdvanced")]
    public class TournamentAdvanced : GlobalMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new TournamentAdvanced();
		}

		#endregion Overriden

		#region Constructor

        public TournamentAdvanced(string name, bool isCustom)
        {
            parameters.Add(name);
            log = "TournamentAdvanced";
            if (isCustom)
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
            }
            else
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromHours(6)));
            }
        }

        public TournamentAdvanced()
        {
            log = "TournamentAdvanced";
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
        }

		#endregion Constructor

	};
}
