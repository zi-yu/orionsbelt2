using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Loki.Exceptions;
using Loki.Interfaces;
using Loki.Generic;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Specialized Memory class for ExceptionInfo
    /// </summary>
	public class SpecializedMemoryExceptionInfo : ExceptionInfo {
	
		#region Fields
		
		private Principal principal;

		#endregion Fields
		
		#region ExceptionInfo Implementation
	
		/// <summary>
        /// Gets the ExceptionInfo's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		#endregion ExceptionInfo Implementation
		
	};
}
