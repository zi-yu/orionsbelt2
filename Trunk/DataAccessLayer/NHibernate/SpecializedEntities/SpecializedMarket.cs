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
    /// Specialized NHibernate class for Market
    /// </summary>
	public class SpecializedMarket : Market {
	
		#region Fields
		
		private System.Collections.Generic.IList<Product> products;
		private SectorStorage sector;

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
		
		#region Market Implementation
	
		/// <summary>
        /// Gets the Market's Products
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Product> Products {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.products == null ) {
					this.products = new List<Product>();
				}
				CheckCollectionSession(this.products);
				return this.ProductsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Product> bag = this.products as NHibernate.Collection.Generic.PersistentGenericBag<Product>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.products = new List<Product>(bag);
                    } else {
                        this.products = null;
                    }
                }
				if( this.products == null ) {
					if (Transient) {
						this.products = new List<Product>();
					} else {
						using( IProductPersistance persistance = Persistance.Instance.GetProductPersistance ()) {
							this.products = persistance.SelectByMarket (this);
						}
						if( this.products == null ) {
							this.products = new List<Product>();
						}
					}
				}
				return this.products;
#endif
			} 
			set {
				this.products = value;
			}
		}
		
		/// <summary>
        /// Gets the Market's Products NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Product> ProductsNHibernate {
			get { return this.products; } 
			set { this.products = value; }
		}

		/// <summary>
        /// Gets the Market's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				CheckSession(this.sector);
				return this.sector;
			}
			set { this.sector = value; }
		}
		
		/// <summary>
        /// Gets the Market's Sector
        /// </summary>
		internal virtual SpecializedSectorStorage SectorNHibernate {
			get { return (SpecializedSectorStorage) this.sector;}
			set { this.sector = value; }
		}

		#endregion Market Implementation
		
	};
}
