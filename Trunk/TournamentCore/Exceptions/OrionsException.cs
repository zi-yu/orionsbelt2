using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.TournamentCore.Exceptions
{
    public class OrionsException : TournamentException
    {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="count1">list 1 count</param>
        /// <param name="count2">list 2 count</param>
        public OrionsException(int count1, int count2)
            : base(String.Format("Number of elements in list 1 = {0}; Number of elements in list 2 = {1}", count1, count2)) { }
    
        /// <summary>
        /// ELOException constructor
        /// </summary>
        /// <param name="error">Error description</param>
        public OrionsException(string error)
            :base(error){}

    }
}
