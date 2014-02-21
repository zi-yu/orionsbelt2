using System;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions
{
    public class InvalidPlayerException : OrionsBeltException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public InvalidPlayerException(string error)
            :base(error){}

    }
}
