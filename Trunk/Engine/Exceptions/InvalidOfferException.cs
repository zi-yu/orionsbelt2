using System;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions
{
    public class InvalidOfferException : OrionsBeltException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public InvalidOfferException(string error)
            :base(error){}

    }
}
