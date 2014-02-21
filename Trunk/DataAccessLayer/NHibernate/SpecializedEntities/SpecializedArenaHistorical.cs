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
    /// Specialized NHibernate class for ArenaHistorical
    /// </summary>
	public class SpecializedArenaHistorical : ArenaHistorical {
	
		#region Fields
		
		private ArenaStorage arena;

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
		
		#region ArenaHistorical Implementation
	
		/// <summary>
        /// Gets the ArenaHistorical's Arena
        /// </summary>
		public override ArenaStorage Arena {
			get { 
				CheckSession(this.arena);
				return this.arena;
			}
			set { this.arena = value; }
		}
		
		/// <summary>
        /// Gets the ArenaHistorical's Arena
        /// </summary>
		internal virtual SpecializedArenaStorage ArenaNHibernate {
			get { return (SpecializedArenaStorage) this.arena;}
			set { this.arena = value; }
		}

		#endregion ArenaHistorical Implementation
		
	};
}
