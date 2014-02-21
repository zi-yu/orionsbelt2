using System;

namespace OrionsBelt.DataAccessLayer {
	
    /// <summary>
    /// DALException exception
    /// </summary>
	public class DALException : OrionsBelt.Core.OrionsBeltException {

        #region Constructors
        
		/// <summary>
        /// DALException constructor
        /// </summary>
        public DALException () 
        {
        }

		/// <summary>
        /// DALException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public DALException( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public DALException(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// DALException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public DALException( string reason, params object[] args) 
			: base(string.Format(reason, args))
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
        public DALException(string reason, Exception ex, params object[] args )
            : base(string.Format(reason, args), ex)
        {
        }

        #endregion Constructors

    };

}