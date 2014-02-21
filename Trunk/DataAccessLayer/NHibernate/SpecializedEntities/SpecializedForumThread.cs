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
    /// Specialized NHibernate class for ForumThread
    /// </summary>
	public class SpecializedForumThread : ForumThread {
	
		#region Fields
		
		private System.Collections.Generic.IList<ForumPost> posts;
		private System.Collections.Generic.IList<ForumReadMarking> readMarkings;
		private ForumTopic topic;
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
		
		#region ForumThread Implementation
	
		/// <summary>
        /// Gets the ForumThread's Posts
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumPost> Posts {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.posts == null ) {
					this.posts = new List<ForumPost>();
				}
				CheckCollectionSession(this.posts);
				return this.PostsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ForumPost> bag = this.posts as NHibernate.Collection.Generic.PersistentGenericBag<ForumPost>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.posts = new List<ForumPost>(bag);
                    } else {
                        this.posts = null;
                    }
                }
				if( this.posts == null ) {
					if (Transient) {
						this.posts = new List<ForumPost>();
					} else {
						using( IForumPostPersistance persistance = Persistance.Instance.GetForumPostPersistance ()) {
							this.posts = persistance.SelectByThread (this);
						}
						if( this.posts == null ) {
							this.posts = new List<ForumPost>();
						}
					}
				}
				return this.posts;
#endif
			} 
			set {
				this.posts = value;
			}
		}
		
		/// <summary>
        /// Gets the ForumThread's Posts NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumPost> PostsNHibernate {
			get { return this.posts; } 
			set { this.posts = value; }
		}

		/// <summary>
        /// Gets the ForumThread's ReadMarkings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ForumReadMarking> ReadMarkings {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.readMarkings == null ) {
					this.readMarkings = new List<ForumReadMarking>();
				}
				CheckCollectionSession(this.readMarkings);
				return this.ReadMarkingsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ForumReadMarking> bag = this.readMarkings as NHibernate.Collection.Generic.PersistentGenericBag<ForumReadMarking>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.readMarkings = new List<ForumReadMarking>(bag);
                    } else {
                        this.readMarkings = null;
                    }
                }
				if( this.readMarkings == null ) {
					if (Transient) {
						this.readMarkings = new List<ForumReadMarking>();
					} else {
						using( IForumReadMarkingPersistance persistance = Persistance.Instance.GetForumReadMarkingPersistance ()) {
							this.readMarkings = persistance.SelectByThread (this);
						}
						if( this.readMarkings == null ) {
							this.readMarkings = new List<ForumReadMarking>();
						}
					}
				}
				return this.readMarkings;
#endif
			} 
			set {
				this.readMarkings = value;
			}
		}
		
		/// <summary>
        /// Gets the ForumThread's ReadMarkings NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumReadMarking> ReadMarkingsNHibernate {
			get { return this.readMarkings; } 
			set { this.readMarkings = value; }
		}

		/// <summary>
        /// Gets the ForumThread's Topic
        /// </summary>
		public override ForumTopic Topic {
			get { 
				CheckSession(this.topic);
				return this.topic;
			}
			set { this.topic = value; }
		}
		
		/// <summary>
        /// Gets the ForumThread's Topic
        /// </summary>
		internal virtual SpecializedForumTopic TopicNHibernate {
			get { return (SpecializedForumTopic) this.topic;}
			set { this.topic = value; }
		}

		/// <summary>
        /// Gets the ForumThread's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the ForumThread's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		#endregion ForumThread Implementation
		
	};
}
