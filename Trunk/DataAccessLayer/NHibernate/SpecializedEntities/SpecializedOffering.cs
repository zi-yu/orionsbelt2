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
    /// Specialized NHibernate class for Offering
    /// </summary>
	public class SpecializedOffering : Offering {
	
		#region Fields
		
		private PlayerStorage donor;
		private PlayerStorage receiver;
		private AllianceStorage alliance;

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
		
		#region Offering Implementation
	
		/// <summary>
        /// Gets the Offering's Donor
        /// </summary>
		public override PlayerStorage Donor {
			get { 
				CheckSession(this.donor);
				return this.donor;
			}
			set { this.donor = value; }
		}
		
		/// <summary>
        /// Gets the Offering's Donor
        /// </summary>
		internal virtual SpecializedPlayerStorage DonorNHibernate {
			get { return (SpecializedPlayerStorage) this.donor;}
			set { this.donor = value; }
		}

		/// <summary>
        /// Gets the Offering's Receiver
        /// </summary>
		public override PlayerStorage Receiver {
			get { 
				CheckSession(this.receiver);
				return this.receiver;
			}
			set { this.receiver = value; }
		}
		
		/// <summary>
        /// Gets the Offering's Receiver
        /// </summary>
		internal virtual SpecializedPlayerStorage ReceiverNHibernate {
			get { return (SpecializedPlayerStorage) this.receiver;}
			set { this.receiver = value; }
		}

		/// <summary>
        /// Gets the Offering's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				CheckSession(this.alliance);
				return this.alliance;
			}
			set { this.alliance = value; }
		}
		
		/// <summary>
        /// Gets the Offering's Alliance
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceNHibernate {
			get { return (SpecializedAllianceStorage) this.alliance;}
			set { this.alliance = value; }
		}

		#endregion Offering Implementation
		
	};
}
