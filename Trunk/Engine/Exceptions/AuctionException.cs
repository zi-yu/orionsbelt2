using System;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions
{
    public class AuctionException : OrionsBeltException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public AuctionException(string error)
            :base(error){}

    }
}
