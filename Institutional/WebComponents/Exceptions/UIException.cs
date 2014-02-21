using System;

namespace Institutional.WebComponents {
	
    /// <summary>
    /// UIException exception
    /// </summary>
	public class UIException : Institutional.Core.InstitutionalException {

        #region Constructors
        
		/// <summary>
        /// UIException constructor
        /// </summary>
        public UIException () 
        {
        }

		/// <summary>
        /// UIException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public UIException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public UIException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// UIException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public UIException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public UIException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}