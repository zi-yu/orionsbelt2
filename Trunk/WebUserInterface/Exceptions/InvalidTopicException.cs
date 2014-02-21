
using System;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Exceptions {
	public class InvalidTopicException: UIException {

		#region Constructors
        
		/// <summary>
        /// BattleException constructor
        /// </summary>
        public InvalidTopicException () 
        {
        }

		/// <summary>
        /// BattleException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public InvalidTopicException( int topicId ) 
			: base(string.Format("Invalid Forum Topic Id: {0}",topicId))
        {
        }
		
        #endregion Constructors


	}
}
