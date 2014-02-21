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
    /// Specialized NHibernate class for Product
    /// </summary>
	public class SpecializedProduct : Product {
	
		#region Fields
		
		private Market market;

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
		
		#region Product Implementation
	
		/// <summary>
        /// Gets the Product's Market
        /// </summary>
		public override Market Market {
			get { 
				CheckSession(this.market);
				return this.market;
			}
			set { this.market = value; }
		}
		
		/// <summary>
        /// Gets the Product's Market
        /// </summary>
		internal virtual SpecializedMarket MarketNHibernate {
			get { return (SpecializedMarket) this.market;}
			set { this.market = value; }
		}

		#endregion Product Implementation
		
	};
}
