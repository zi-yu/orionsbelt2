using System;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions
{
    public class InvalidAllianceException : OrionsBeltException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public InvalidAllianceException(string error)
            :base(error){}

    }
}
