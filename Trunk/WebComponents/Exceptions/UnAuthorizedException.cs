using System;

namespace OrionsBelt.WebComponents {
	
    /// <summary>
    /// UnAuthorizedException exception
    /// </summary>
	public class UnAuthorizedException : OrionsBelt.WebComponents.UIException {

        #region Constructors
        
		/// <summary>
        /// UnAuthorizedException constructor
        /// </summary>
        public UnAuthorizedException () 
        {
        }

		/// <summary>
        /// UnAuthorizedException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public UnAuthorizedException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public UnAuthorizedException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// UnAuthorizedException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public UnAuthorizedException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public UnAuthorizedException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}