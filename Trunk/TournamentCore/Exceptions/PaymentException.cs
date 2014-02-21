using OrionsBelt.Core;

namespace OrionsBelt.TournamentCore.Exceptions
{

    public class PaymentException : OrionsBeltException
    {

        public PaymentException()
        { }

        public PaymentException(string reason)
            : base(reason) { }

    }
}
