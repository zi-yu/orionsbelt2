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
    /// Specialized NHibernate class for AllianceDiplomacy
    /// </summary>
	public class SpecializedAllianceDiplomacy : AllianceDiplomacy {
	
		#region Fields
		
		private AllianceStorage allianceA;
		private AllianceStorage allianceB;

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
		
		#region AllianceDiplomacy Implementation
	
		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceA
        /// </summary>
		public override AllianceStorage AllianceA {
			get { 
				CheckSession(this.allianceA);
				return this.allianceA;
			}
			set { this.allianceA = value; }
		}
		
		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceA
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceANHibernate {
			get { return (SpecializedAllianceStorage) this.allianceA;}
			set { this.allianceA = value; }
		}

		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceB
        /// </summary>
		public override AllianceStorage AllianceB {
			get { 
				CheckSession(this.allianceB);
				return this.allianceB;
			}
			set { this.allianceB = value; }
		}
		
		/// <summary>
        /// Gets the AllianceDiplomacy's AllianceB
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceBNHibernate {
			get { return (SpecializedAllianceStorage) this.allianceB;}
			set { this.allianceB = value; }
		}

		#endregion AllianceDiplomacy Implementation
		
	};
}
