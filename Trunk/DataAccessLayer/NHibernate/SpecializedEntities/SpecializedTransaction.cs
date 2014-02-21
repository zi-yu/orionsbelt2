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
    /// Specialized NHibernate class for Transaction
    /// </summary>
	public class SpecializedTransaction : Transaction {
	
		#region Fields
		
		private System.Collections.Generic.IList<Invoice> invoice;

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
		
		#region Transaction Implementation
	
		/// <summary>
        /// Gets the Transaction's Invoice
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Invoice> Invoice {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.invoice == null ) {
					this.invoice = new List<Invoice>();
				}
				CheckCollectionSession(this.invoice);
				return this.InvoiceNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Invoice> bag = this.invoice as NHibernate.Collection.Generic.PersistentGenericBag<Invoice>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.invoice = new List<Invoice>(bag);
                    } else {
                        this.invoice = null;
                    }
                }
				if( this.invoice == null ) {
					if (Transient) {
						this.invoice = new List<Invoice>();
					} else {
						using( IInvoicePersistance persistance = Persistance.Instance.GetInvoicePersistance ()) {
							this.invoice = persistance.SelectByTransaction (this);
						}
						if( this.invoice == null ) {
							this.invoice = new List<Invoice>();
						}
					}
				}
				return this.invoice;
#endif
			} 
			set {
				this.invoice = value;
			}
		}
		
		/// <summary>
        /// Gets the Transaction's Invoice NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Invoice> InvoiceNHibernate {
			get { return this.invoice; } 
			set { this.invoice = value; }
		}

		#endregion Transaction Implementation
		
	};
}
