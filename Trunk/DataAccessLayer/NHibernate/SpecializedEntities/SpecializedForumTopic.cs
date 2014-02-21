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
    /// Specialized NHibernate class for ForumTopic
    /// </summary>
	public class SpecializedForumTopic : ForumTopic {
	
		#region Fields
		
		private System.Collections.Generic.IList<ForumThread> threads;

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
		
		#region ForumTopic Implementation
	
		/// <summary>
        /// Gets the ForumTopic's Threads
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumThread> Threads {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.threads == null ) {
					this.threads = new List<ForumThread>();
				}
				CheckCollectionSession(this.threads);
				return this.ThreadsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ForumThread> bag = this.threads as NHibernate.Collection.Generic.PersistentGenericBag<ForumThread>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.threads = new List<ForumThread>(bag);
                    } else {
                        this.threads = null;
                    }
                }
				if( this.threads == null ) {
					if (Transient) {
						this.threads = new List<ForumThread>();
					} else {
						using( IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance ()) {
							this.threads = persistance.SelectByTopic (this);
						}
						if( this.threads == null ) {
							this.threads = new List<ForumThread>();
						}
					}
				}
				return this.threads;
#endif
			} 
			set {
				this.threads = value;
			}
		}
		
		/// <summary>
        /// Gets the ForumTopic's Threads NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumThread> ThreadsNHibernate {
			get { return this.threads; } 
			set { this.threads = value; }
		}

		#endregion ForumTopic Implementation
		
	};
}
