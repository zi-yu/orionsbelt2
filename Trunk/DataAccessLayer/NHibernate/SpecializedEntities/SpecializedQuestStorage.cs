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
    /// Specialized NHibernate class for QuestStorage
    /// </summary>
	public class SpecializedQuestStorage : QuestStorage {
	
		#region Fields
		
		private PlayerStorage player;

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
		
		#region QuestStorage Implementation
	
		/// <summary>
        /// Gets the QuestStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				CheckSession(this.player);
				return this.player;
			}
			set { this.player = value; }
		}
		
		/// <summary>
        /// Gets the QuestStorage's Player
        /// </summary>
		internal virtual SpecializedPlayerStorage PlayerNHibernate {
			get { return (SpecializedPlayerStorage) this.player;}
			set { this.player = value; }
		}

		#endregion QuestStorage Implementation
		
	};
}
