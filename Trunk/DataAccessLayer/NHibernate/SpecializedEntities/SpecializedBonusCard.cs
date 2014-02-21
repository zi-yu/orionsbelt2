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
    /// Specialized NHibernate class for BonusCard
    /// </summary>
	public class SpecializedBonusCard : BonusCard {
	
		#region Fields
		
		private Principal usedBy;

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
		
		#region BonusCard Implementation
	
		/// <summary>
        /// Gets the BonusCard's UsedBy
        /// </summary>
		public override Principal UsedBy {
			get { 
				CheckSession(this.usedBy);
				return this.usedBy;
			}
			set { this.usedBy = value; }
		}
		
		/// <summary>
        /// Gets the BonusCard's UsedBy
        /// </summary>
		internal virtual SpecializedPrincipal UsedByNHibernate {
			get { return (SpecializedPrincipal) this.usedBy;}
			set { this.usedBy = value; }
		}

		#endregion BonusCard Implementation
		
	};
}
