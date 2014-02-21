using OrionsBelt.Core;

namespace OrionsBelt.TournamentCore.Exceptions
{

    public class ArenaException : OrionsBeltException
    {

        public ArenaException()
        { }

        public ArenaException(string reason)
            : base(reason) { }

    }
}
