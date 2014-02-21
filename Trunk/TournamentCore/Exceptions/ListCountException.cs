using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.TournamentCore.Exceptions
{
    public class ListCountException : TournamentException
    {
        /// <summary>
        /// ListCount constructor
        /// </summary>
        /// <param name="expected">Number of elements expeted</param>
        /// <param name="had">Number of elements had</param>
        public ListCountException(int expected, int had)
            : base(String.Format("Expeted = {0}; Had = {1}", expected, had)) { }

        /// <summary>
        /// ListCount constructor
        /// </summary>
        /// <param name="notExpected1">Number of elements not expeted</param>
        /// <param name="notExpected2">Number of elements not expeted</param>
        /// /// <param name="different">Forbidden number</param>
        public ListCountException(int notExpected1, int notExpected2, int different)
            : base(String.Format("The lists have {0} and {1} elements. Both must be different from {2}", notExpected1, notExpected2, different)) { }
    }
}
