using System;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions
{
    public class TeamException : OrionsBeltException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public TeamException(string error)
            :base(error){}

    }
}
