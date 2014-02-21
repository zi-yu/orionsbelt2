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
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Specialized Memory class for Payment
    /// </summary>
	public class SpecializedMemoryPayment : Payment {
	
		#region Fields
		
		private System.Collections.Generic.IList<Invoice> invoice;

		#endregion Fields
		
		#region Payment Implementation
	
		/// <summary>
        /// Gets the Payment's Invoice
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Invoice> Invoice {
			get {
				if( this.invoice == null ) {
					this.invoice = new List<Invoice>();
				}
				return this.invoice;
			} 
			set {
				this.invoice = value;
			}
		}

		#endregion Payment Implementation
		
	};
}
