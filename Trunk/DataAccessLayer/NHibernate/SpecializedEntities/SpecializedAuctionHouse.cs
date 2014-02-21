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
    /// Specialized NHibernate class for AuctionHouse
    /// </summary>
	public class SpecializedAuctionHouse : AuctionHouse {
	
		#region Fields
		
		private System.Collections.Generic.IList<BidHistorical> bids;
		private PlayerStorage owner;

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
		
		#region AuctionHouse Implementation
	
		/// <summary>
        /// Gets the AuctionHouse's Bids
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BidHistorical> Bids {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.bids == null ) {
					this.bids = new List<BidHistorical>();
				}
				CheckCollectionSession(this.bids);
				return this.BidsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<BidHistorical> bag = this.bids as NHibernate.Collection.Generic.PersistentGenericBag<BidHistorical>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.bids = new List<BidHistorical>(bag);
                    } else {
                        this.bids = null;
                    }
                }
				if( this.bids == null ) {
					if (Transient) {
						this.bids = new List<BidHistorical>();
					} else {
						using( IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance ()) {
							this.bids = persistance.SelectByResource (this);
						}
						if( this.bids == null ) {
							this.bids = new List<BidHistorical>();
						}
					}
				}
				return this.bids;
#endif
			} 
			set {
				this.bids = value;
			}
		}
		
		/// <summary>
        /// Gets the AuctionHouse's Bids NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BidHistorical> BidsNHibernate {
			get { return this.bids; } 
			set { this.bids = value; }
		}

		/// <summary>
        /// Gets the AuctionHouse's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the AuctionHouse's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		#endregion AuctionHouse Implementation
		
	};
}
