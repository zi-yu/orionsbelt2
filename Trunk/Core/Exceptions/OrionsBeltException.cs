using System;

namespace OrionsBelt.Core {
	
    /// <summary>
    /// OrionsBeltException exception
    /// </summary>
	public class OrionsBeltException : Exception {

        #region Constructors
        
		/// <summary>
        /// OrionsBeltException constructor
        /// </summary>
        public OrionsBeltException () 
        {
        }

		/// <summary>
        /// OrionsBeltException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public OrionsBeltException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public OrionsBeltException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// OrionsBeltException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public OrionsBeltException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public OrionsBeltException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}