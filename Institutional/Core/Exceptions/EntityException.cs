using System;

namespace Institutional.Core {
	
    /// <summary>
    /// EntityException exception
    /// </summary>
	public class EntityException : Institutional.Core.InstitutionalException {

        #region Constructors
        
		/// <summary>
        /// EntityException constructor
        /// </summary>
        public EntityException () 
        {
        }

		/// <summary>
        /// EntityException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public EntityException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public EntityException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// EntityException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public EntityException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public EntityException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}