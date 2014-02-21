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
    /// Specialized NHibernate class for ForumPost
    /// </summary>
	public class SpecializedForumPost : ForumPost {
	
		#region Fields
		
		private ForumThread thread;
		private PlayerStorage owner;

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
		
		#region ForumPost Implementation
	
		/// <summary>
        /// Gets the ForumPost's Thread
        /// </summary>
		public override ForumThread Thread {
			get { 
				CheckSession(this.thread);
				return this.thread;
			}
			set { this.thread = value; }
		}
		
		/// <summary>
        /// Gets the ForumPost's Thread
        /// </summary>
		internal virtual SpecializedForumThread ThreadNHibernate {
			get { return (SpecializedForumThread) this.thread;}
			set { this.thread = value; }
		}

		/// <summary>
        /// Gets the ForumPost's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the ForumPost's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		#endregion ForumPost Implementation
		
	};
}
