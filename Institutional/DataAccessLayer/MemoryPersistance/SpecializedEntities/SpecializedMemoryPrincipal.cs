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
    /// Specialized Memory class for Principal
    /// </summary>
	public class SpecializedMemoryPrincipal : Principal {
	
		#region Fields
		
		private System.Collections.Generic.IList<ExceptionInfo> exceptions;

		#endregion Fields
		
		#region Principal Implementation
	
		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ExceptionInfo> Exceptions {
			get {
				if( this.exceptions == null ) {
					this.exceptions = new List<ExceptionInfo>();
				}
				return this.exceptions;
			} 
			set {
				this.exceptions = value;
			}
		}

		#endregion Principal Implementation
		
	};
}
