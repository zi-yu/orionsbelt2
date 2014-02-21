using System;

namespace Institutional.WebComponents {
	
    /// <summary>
    /// UnAuthenticatedException exception
    /// </summary>
	public class UnAuthenticatedException : Institutional.WebComponents.UIException {

        #region Constructors
        
		/// <summary>
        /// UnAuthenticatedException constructor
        /// </summary>
        public UnAuthenticatedException () 
        {
        }

		/// <summary>
        /// UnAuthenticatedException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public UnAuthenticatedException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public UnAuthenticatedException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// UnAuthenticatedException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public UnAuthenticatedException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public UnAuthenticatedException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}