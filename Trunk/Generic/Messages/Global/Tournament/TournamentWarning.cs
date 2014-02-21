using DesignPatterns.Attributes;
using System;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("TournamentWarning")]
    public class TournamentWarning : GlobalMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new TournamentWarning();
		}

        public override string Translate()
        {
            string param1 = Parameters[0];
            string param2 = TimeFormatter.GetFormattedTicksTo(Convert.ToInt32(Parameters[1]));

            return string.Format(LanguageTranslator.Translate(SubCategory), param1, param2);
        }

		#endregion Overriden

		#region Constructor

        public TournamentWarning(string name, int tick)
        {
            parameters.Add(name);
            parameters.Add(tick.ToString());
            log = "TournamentWarning";
            TickDeadline = Clock.Instance.EndTickByDelay( Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
		}

        public TournamentWarning()
        {
            log = "TournamentWarning";
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
        }

		#endregion Constructor

	};
}
