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
    /// Specialized NHibernate class for Necessity
    /// </summary>
	public class SpecializedNecessity : Necessity {
	
		#region Fields
		
		private System.Collections.Generic.IList<Task> tasks;
		private PlayerStorage creator;
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
		
		#region Necessity Implementation
	
		/// <summary>
        /// Gets the Necessity's Tasks
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Task> Tasks {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.tasks == null ) {
					this.tasks = new List<Task>();
				}
				CheckCollectionSession(this.tasks);
				return this.TasksNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Task> bag = this.tasks as NHibernate.Collection.Generic.PersistentGenericBag<Task>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.tasks = new List<Task>(bag);
                    } else {
                        this.tasks = null;
                    }
                }
				if( this.tasks == null ) {
					if (Transient) {
						this.tasks = new List<Task>();
					} else {
						using( ITaskPersistance persistance = Persistance.Instance.GetTaskPersistance ()) {
							this.tasks = persistance.SelectByNecessity (this);
						}
						if( this.tasks == null ) {
							this.tasks = new List<Task>();
						}
					}
				}
				return this.tasks;
#endif
			} 
			set {
				this.tasks = value;
			}
		}
		
		/// <summary>
        /// Gets the Necessity's Tasks NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Task> TasksNHibernate {
			get { return this.tasks; } 
			set { this.tasks = value; }
		}

		/// <summary>
        /// Gets the Necessity's Creator
        /// </summary>
		public override PlayerStorage Creator {
			get { 
				CheckSession(this.creator);
				return this.creator;
			}
			set { this.creator = value; }
		}
		
		/// <summary>
        /// Gets the Necessity's Creator
        /// </summary>
		internal virtual SpecializedPlayerStorage CreatorNHibernate {
			get { return (SpecializedPlayerStorage) this.creator;}
			set { this.creator = value; }
		}

		/// <summary>
        /// Gets the Necessity's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				CheckSession(this.alliance);
				return this.alliance;
			}
			set { this.alliance = value; }
		}
		
		/// <summary>
        /// Gets the Necessity's Alliance
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceNHibernate {
			get { return (SpecializedAllianceStorage) this.alliance;}
			set { this.alliance = value; }
		}

		#endregion Necessity Implementation
		
	};
}
