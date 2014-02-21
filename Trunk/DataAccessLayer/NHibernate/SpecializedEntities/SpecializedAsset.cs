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
    /// Specialized NHibernate class for Asset
    /// </summary>
	public class SpecializedAsset : Asset {
	
		#region Fields
		
		private PlayerStorage owner;
		private Task task;
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
		
		#region Asset Implementation
	
		/// <summary>
        /// Gets the Asset's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the Asset's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the Asset's Task
        /// </summary>
		public override Task Task {
			get { 
				CheckSession(this.task);
				return this.task;
			}
			set { this.task = value; }
		}
		
		/// <summary>
        /// Gets the Asset's Task
        /// </summary>
		internal virtual SpecializedTask TaskNHibernate {
			get { return (SpecializedTask) this.task;}
			set { this.task = value; }
		}

		/// <summary>
        /// Gets the Asset's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				CheckSession(this.alliance);
				return this.alliance;
			}
			set { this.alliance = value; }
		}
		
		/// <summary>
        /// Gets the Asset's Alliance
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceNHibernate {
			get { return (SpecializedAllianceStorage) this.alliance;}
			set { this.alliance = value; }
		}

		#endregion Asset Implementation
		
	};
}
