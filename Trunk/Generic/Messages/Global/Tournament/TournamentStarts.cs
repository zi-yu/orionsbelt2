using DesignPatterns.Attributes;
using System;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("TournamentStarts")]
    public class TournamentStarts : GlobalMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new TournamentStarts();
		}

		#endregion Overriden

		#region Constructor

        public TournamentStarts(string name)
        {
            parameters.Add(name);
            log = "TournamentStarts";
            TickDeadline = Clock.Instance.EndTickByDelay( Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
		}

        public TournamentStarts(string name, bool isMini)
        {
            parameters.Add(name);
            log = "TournamentStarts";
            if (isMini)
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromHours(6)));
            }
            else
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
            }
        }

        public TournamentStarts()
        {
            log = "TournamentStarts";
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
        }

		#endregion Constructor

	};
}
