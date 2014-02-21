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
    /// Specialized NHibernate class for BidHistorical
    /// </summary>
	public class SpecializedBidHistorical : BidHistorical {
	
		#region Fields
		
		private AuctionHouse resource;
		private PlayerStorage madeBy;

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
		
		#region BidHistorical Implementation
	
		/// <summary>
        /// Gets the BidHistorical's Resource
        /// </summary>
		public override AuctionHouse Resource {
			get { 
				CheckSession(this.resource);
				return this.resource;
			}
			set { this.resource = value; }
		}
		
		/// <summary>
        /// Gets the BidHistorical's Resource
        /// </summary>
		internal virtual SpecializedAuctionHouse ResourceNHibernate {
			get { return (SpecializedAuctionHouse) this.resource;}
			set { this.resource = value; }
		}

		/// <summary>
        /// Gets the BidHistorical's MadeBy
        /// </summary>
		public override PlayerStorage MadeBy {
			get { 
				CheckSession(this.madeBy);
				return this.madeBy;
			}
			set { this.madeBy = value; }
		}
		
		/// <summary>
        /// Gets the BidHistorical's MadeBy
        /// </summary>
		internal virtual SpecializedPlayerStorage MadeByNHibernate {
			get { return (SpecializedPlayerStorage) this.madeBy;}
			set { this.madeBy = value; }
		}

		#endregion BidHistorical Implementation
		
	};
}
