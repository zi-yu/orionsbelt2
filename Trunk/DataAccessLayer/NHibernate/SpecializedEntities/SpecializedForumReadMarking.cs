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
    /// Specialized NHibernate class for ForumReadMarking
    /// </summary>
	public class SpecializedForumReadMarking : ForumReadMarking {
	
		#region Fields
		
		private PlayerStorage player;
		private ForumThread thread;

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
		
		#region ForumReadMarking Implementation
	
		/// <summary>
        /// Gets the ForumReadMarking's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				CheckSession(this.player);
				return this.player;
			}
			set { this.player = value; }
		}
		
		/// <summary>
        /// Gets the ForumReadMarking's Player
        /// </summary>
		internal virtual SpecializedPlayerStorage PlayerNHibernate {
			get { return (SpecializedPlayerStorage) this.player;}
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the ForumReadMarking's Thread
        /// </summary>
		public override ForumThread Thread {
			get { 
				CheckSession(this.thread);
				return this.thread;
			}
			set { this.thread = value; }
		}
		
		/// <summary>
        /// Gets the ForumReadMarking's Thread
        /// </summary>
		internal virtual SpecializedForumThread ThreadNHibernate {
			get { return (SpecializedForumThread) this.thread;}
			set { this.thread = value; }
		}

		#endregion ForumReadMarking Implementation
		
	};
}
