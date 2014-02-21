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
    /// Specialized Memory class for Invoice
    /// </summary>
	public class SpecializedMemoryInvoice : Invoice {
	
		#region Fields
		
		private Transaction transaction;
		private Payment payment;

		#endregion Fields
		
		#region Invoice Implementation
	
		/// <summary>
        /// Gets the Invoice's Transaction
        /// </summary>
		public override Transaction Transaction {
			get { 
				return this.transaction;
			}
			set { this.transaction = value; }
		}

		/// <summary>
        /// Gets the Invoice's Payment
        /// </summary>
		public override Payment Payment {
			get { 
				return this.payment;
			}
			set { this.payment = value; }
		}

		#endregion Invoice Implementation
		
	};
}
