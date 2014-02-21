using OrionsBelt.Core;

namespace OrionsBelt.TournamentCore.Exceptions
{

    public class SoldOutException : OrionsBeltException
    {

        public SoldOutException()
        { }

        public SoldOutException(string reason)
            : base(reason) { }

    }
}
