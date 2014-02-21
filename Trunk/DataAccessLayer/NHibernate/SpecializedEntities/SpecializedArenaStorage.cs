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
    /// Specialized NHibernate class for ArenaStorage
    /// </summary>
	public class SpecializedArenaStorage : ArenaStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<ArenaHistorical> historical;
		private Fleet fleet;
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
		
		#region ArenaStorage Implementation
	
		/// <summary>
        /// Gets the ArenaStorage's Historical
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaHistorical> Historical {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.historical == null ) {
					this.historical = new List<ArenaHistorical>();
				}
				CheckCollectionSession(this.historical);
				return this.HistoricalNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ArenaHistorical> bag = this.historical as NHibernate.Collection.Generic.PersistentGenericBag<ArenaHistorical>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.historical = new List<ArenaHistorical>(bag);
                    } else {
                        this.historical = null;
                    }
                }
				if( this.historical == null ) {
					if (Transient) {
						this.historical = new List<ArenaHistorical>();
					} else {
						using( IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance ()) {
							this.historical = persistance.SelectByArena (this);
						}
						if( this.historical == null ) {
							this.historical = new List<ArenaHistorical>();
						}
					}
				}
				return this.historical;
#endif
			} 
			set {
				this.historical = value;
			}
		}
		
		/// <summary>
        /// Gets the ArenaStorage's Historical NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ArenaHistorical> HistoricalNHibernate {
			get { return this.historical; } 
			set { this.historical = value; }
		}

		/// <summary>
        /// Gets the ArenaStorage's Fleet
        /// </summary>
		public override Fleet Fleet {
			get { 
				CheckSession(this.fleet);
				return this.fleet;
			}
			set { this.fleet = value; }
		}
		
		/// <summary>
        /// Gets the ArenaStorage's Fleet
        /// </summary>
		internal virtual SpecializedFleet FleetNHibernate {
			get { return (SpecializedFleet) this.fleet;}
			set { this.fleet = value; }
		}

		/// <summary>
        /// Gets the ArenaStorage's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the ArenaStorage's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the ArenaStorage's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				CheckSession(this.sector);
				return this.sector;
			}
			set { this.sector = value; }
		}
		
		/// <summary>
        /// Gets the ArenaStorage's Sector
        /// </summary>
		internal virtual SpecializedSectorStorage SectorNHibernate {
			get { return (SpecializedSectorStorage) this.sector;}
			set { this.sector = value; }
		}

		#endregion ArenaStorage Implementation
		
	};
}
