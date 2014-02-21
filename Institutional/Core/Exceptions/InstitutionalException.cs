using System;

namespace Institutional.Core {
	
    /// <summary>
    /// InstitutionalException exception
    /// </summary>
	public class InstitutionalException : Exception {

        #region Constructors
        
		/// <summary>
        /// InstitutionalException constructor
        /// </summary>
        public InstitutionalException () 
        {
        }

		/// <summary>
        /// InstitutionalException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public InstitutionalException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public InstitutionalException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// InstitutionalException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public InstitutionalException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public InstitutionalException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}