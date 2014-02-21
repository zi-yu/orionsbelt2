
using System;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Exceptions {
	public class BattleExceptionUI: UIException {

		#region Constructors
        
		/// <summary>
        /// BattleException constructor
        /// </summary>
        public BattleExceptionUI () 
        {
        }

		/// <summary>
        /// BattleException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        public BattleExceptionUI( string reason ) 
			: base(reason)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        public BattleExceptionUI(string reason, Exception ex)
            : base(reason, ex)
        {
        }

		/// <summary>
        /// BattleException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
        /// <param name="args">Parameters to format the message</param>
        public BattleExceptionUI( string reason, params object[] args) 
			: base(reason, args)
        {
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">The exception message</param>
        /// <param name="ex">The original exception</param>
        /// <param name="args">Parameters to format the message</param>
		public BattleExceptionUI( string reason, Exception ex, params object[] args )
            : base(reason,ex,args)
        {
        }

        #endregion Constructors


	}
}
