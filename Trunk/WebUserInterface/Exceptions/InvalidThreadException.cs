
using System;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Exceptions {
    public class InvalidThreadException : UIException {

		#region Constructors
        
		/// <summary>
        /// BattleException constructor
        /// </summary>
        public InvalidThreadException () 
        {
        }

		/// <summary>
        /// BattleException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public InvalidThreadException( int threadId )
            : base(string.Format("Invalid Forum Thread Id: {0}", threadId))
        {
        }
		
        #endregion Constructors


	}
}
