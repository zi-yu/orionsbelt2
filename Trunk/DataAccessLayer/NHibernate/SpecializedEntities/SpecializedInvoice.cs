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
    /// Specialized NHibernate class for Invoice
    /// </summary>
	public class SpecializedInvoice : Invoice {
	
		#region Fields
		
		private Transaction transaction;
		private Payment payment;

		#endregion Fields
		
		#region NHibernate Utils

        private ISession session;

        internal virtual ISession NHibernateSession {
            get { return session; }
            set { session = value; }
        }
        
        internal virtual void CheckSession()
        {
            NHibernateUtilities.CheckSession(this);
        }
        
        internal virtual void CheckSession(IEntity entity)
        {
            NHibernateUtilities.CheckSession(entity);
        }
        
        internal virtual void CheckCollectionSession(IEnumerable coll)
        {
            NHibernateUtilities.CheckCollectionSession(NHibernateSession, this, coll);
        }

        #endregion NHibernate Utils
		
		#region Invoice Implementation
	
		/// <summary>
        /// Gets the Invoice's Transaction
        /// </summary>
		public override Transaction Transaction {
			get { 
				CheckSession(this.transaction);
				return this.transaction;
			}
			set { this.transaction = value; }
		}
		
		/// <summary>
        /// Gets the Invoice's Transaction
        /// </summary>
		internal virtual SpecializedTransaction TransactionNHibernate {
			get { return (SpecializedTransaction) this.transaction;}
			set { this.transaction = value; }
		}

		/// <summary>
        /// Gets the Invoice's Payment
        /// </summary>
		public override Payment Payment {
			get { 
				CheckSession(this.payment);
				return this.payment;
			}
			set { this.payment = value; }
		}
		
		/// <summary>
        /// Gets the Invoice's Payment
        /// </summary>
		internal virtual SpecializedPayment PaymentNHibernate {
			get { return (SpecializedPayment) this.payment;}
			set { this.payment = value; }
		}

		#endregion Invoice Implementation
		
	};
}
