using OrionsBelt.Core;

namespace OrionsBelt.TournamentCore.Exceptions
{

    public class TournamentException : OrionsBeltException
    {

        public TournamentException()
        { }

        public TournamentException(string reason)
            : base(reason) { }

    }
}
