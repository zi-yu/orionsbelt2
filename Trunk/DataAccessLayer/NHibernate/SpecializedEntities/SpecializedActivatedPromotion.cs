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
    /// Specialized NHibernate class for ActivatedPromotion
    /// </summary>
	public class SpecializedActivatedPromotion : ActivatedPromotion {
	
		#region Fields
		
		private Promotion promotion;
		private Principal principal;

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
		
		#region ActivatedPromotion Implementation
	
		/// <summary>
        /// Gets the ActivatedPromotion's Promotion
        /// </summary>
		public override Promotion Promotion {
			get { 
				CheckSession(this.promotion);
				return this.promotion;
			}
			set { this.promotion = value; }
		}
		
		/// <summary>
        /// Gets the ActivatedPromotion's Promotion
        /// </summary>
		internal virtual SpecializedPromotion PromotionNHibernate {
			get { return (SpecializedPromotion) this.promotion;}
			set { this.promotion = value; }
		}

		/// <summary>
        /// Gets the ActivatedPromotion's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the ActivatedPromotion's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		#endregion ActivatedPromotion Implementation
		
	};
}
