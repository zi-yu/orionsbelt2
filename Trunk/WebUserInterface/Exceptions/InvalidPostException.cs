
using System;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Exceptions {
	public class InvalidPostException: UIException {

		#region Constructors
        
		/// <summary>
        /// InvalidPostException constructor
        /// </summary>
        public InvalidPostException() 
        {
        }

		/// <summary>
        /// InvalidPostException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public InvalidPostException( int postId )
            : base(string.Format("Invalid Forum Post Id: {0}", postId))
        {
        }
		
        #endregion Constructors


	}
}
