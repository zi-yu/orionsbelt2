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
    /// Specialized NHibernate class for Task
    /// </summary>
	public class SpecializedTask : Task {
	
		#region Fields
		
		private System.Collections.Generic.IList<Asset> assets;
		private Necessity necessity;

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
		
		#region Task Implementation
	
		/// <summary>
        /// Gets the Task's Assets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Asset> Assets {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.assets == null ) {
					this.assets = new List<Asset>();
				}
				CheckCollectionSession(this.assets);
				return this.AssetsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Asset> bag = this.assets as NHibernate.Collection.Generic.PersistentGenericBag<Asset>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.assets = new List<Asset>(bag);
                    } else {
                        this.assets = null;
                    }
                }
				if( this.assets == null ) {
					if (Transient) {
						this.assets = new List<Asset>();
					} else {
						using( IAssetPersistance persistance = Persistance.Instance.GetAssetPersistance ()) {
							this.assets = persistance.SelectByTask (this);
						}
						if( this.assets == null ) {
							this.assets = new List<Asset>();
						}
					}
				}
				return this.assets;
#endif
			} 
			set {
				this.assets = value;
			}
		}
		
		/// <summary>
        /// Gets the Task's Assets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Asset> AssetsNHibernate {
			get { return this.assets; } 
			set { this.assets = value; }
		}

		/// <summary>
        /// Gets the Task's Necessity
        /// </summary>
		public override Necessity Necessity {
			get { 
				CheckSession(this.necessity);
				return this.necessity;
			}
			set { this.necessity = value; }
		}
		
		/// <summary>
        /// Gets the Task's Necessity
        /// </summary>
		internal virtual SpecializedNecessity NecessityNHibernate {
			get { return (SpecializedNecessity) this.necessity;}
			set { this.necessity = value; }
		}

		#endregion Task Implementation
		
	};
}
