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
    /// Specialized NHibernate class for PlanetStorage
    /// </summary>
	public class SpecializedPlanetStorage : PlanetStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlanetResourceStorage> resources;
		private PlayerStorage player;
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
		
		#region PlanetStorage Implementation
	
		/// <summary>
        /// Gets the PlanetStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Fleet> Fleets {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.fleets == null ) {
					this.fleets = new List<Fleet>();
				}
				CheckCollectionSession(this.fleets);
				return this.FleetsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Fleet> bag = this.fleets as NHibernate.Collection.Generic.PersistentGenericBag<Fleet>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.fleets = new List<Fleet>(bag);
                    } else {
                        this.fleets = null;
                    }
                }
				if( this.fleets == null ) {
					if (Transient) {
						this.fleets = new List<Fleet>();
					} else {
						using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance ()) {
							this.fleets = persistance.SelectByCurrentPlanet (this);
						}
						if( this.fleets == null ) {
							this.fleets = new List<Fleet>();
						}
					}
				}
				return this.fleets;
#endif
			} 
			set {
				this.fleets = value;
			}
		}
		
		/// <summary>
        /// Gets the PlanetStorage's Fleets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Fleet> FleetsNHibernate {
			get { return this.fleets; } 
			set { this.fleets = value; }
		}

		/// <summary>
        /// Gets the PlanetStorage's Resources
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetResourceStorage> Resources {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.resources == null ) {
					this.resources = new List<PlanetResourceStorage>();
				}
				CheckCollectionSession(this.resources);
				return this.ResourcesNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlanetResourceStorage> bag = this.resources as NHibernate.Collection.Generic.PersistentGenericBag<PlanetResourceStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.resources = new List<PlanetResourceStorage>(bag);
                    } else {
                        this.resources = null;
                    }
                }
				if( this.resources == null ) {
					if (Transient) {
						this.resources = new List<PlanetResourceStorage>();
					} else {
						using( IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance ()) {
							this.resources = persistance.SelectByPlanet (this);
						}
						if( this.resources == null ) {
							this.resources = new List<PlanetResourceStorage>();
						}
					}
				}
				return this.resources;
#endif
			} 
			set {
				this.resources = value;
			}
		}
		
		/// <summary>
        /// Gets the PlanetStorage's Resources NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlanetResourceStorage> ResourcesNHibernate {
			get { return this.resources; } 
			set { this.resources = value; }
		}

		/// <summary>
        /// Gets the PlanetStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				CheckSession(this.player);
				return this.player;
			}
			set { this.player = value; }
		}
		
		/// <summary>
        /// Gets the PlanetStorage's Player
        /// </summary>
		internal virtual SpecializedPlayerStorage PlayerNHibernate {
			get { return (SpecializedPlayerStorage) this.player;}
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the PlanetStorage's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				CheckSession(this.sector);
				return this.sector;
			}
			set { this.sector = value; }
		}
		
		/// <summary>
        /// Gets the PlanetStorage's Sector
        /// </summary>
		internal virtual SpecializedSectorStorage SectorNHibernate {
			get { return (SpecializedSectorStorage) this.sector;}
			set { this.sector = value; }
		}

		#endregion PlanetStorage Implementation
		
	};
}
