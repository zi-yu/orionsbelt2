using DesignPatterns.Attributes;
using System;

namespace OrionsBelt.Generic.Messages {

    [FactoryKey("NewTournament")]
    public class NewTournament : GlobalMessage {

		#region Overriden

		protected override IMessage CreateMessage( int ownerid, params object[] msgParameters ) {
            return new NewTournament();
		}

        public override Category Category
        {
            get { return Category.Global; }
        }

		#endregion Overriden

		#region Constructor

        public NewTournament(string name)
        {
            parameters.Add(name);
            log = "NewTournament";
            TickDeadline = Clock.Instance.EndTickByDelay( Clock.Instance.ConvertToTicks(TimeSpan.FromDays(5)));
		}

        public NewTournament()
        {
            log = "NewTournament";
            TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(5)));
        }

        public NewTournament(string name, bool isMini)
        {
            parameters.Add(name);
            log = "NewTournament";
            if (isMini)
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromHours(12)));
            }
            else
            {
                TickDeadline = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(5)));
            }
        }

		#endregion Constructor

	};
}
