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
    /// Specialized NHibernate class for UniverseSpecialSector
    /// </summary>
	public class SpecializedUniverseSpecialSector : UniverseSpecialSector {
	
		#region Fields
		
		private PlayerStorage owner;
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
		
		#region UniverseSpecialSector Implementation
	
		/// <summary>
        /// Gets the UniverseSpecialSector's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the UniverseSpecialSector's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				CheckSession(this.sector);
				return this.sector;
			}
			set { this.sector = value; }
		}
		
		/// <summary>
        /// Gets the UniverseSpecialSector's Sector
        /// </summary>
		internal virtual SpecializedSectorStorage SectorNHibernate {
			get { return (SpecializedSectorStorage) this.sector;}
			set { this.sector = value; }
		}

		#endregion UniverseSpecialSector Implementation
		
	};
}
