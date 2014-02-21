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
    /// Specialized NHibernate class for SectorStorage
    /// </summary>
	public class SpecializedSectorStorage : SectorStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlanetStorage> planets;
		private System.Collections.Generic.IList<UniverseSpecialSector> specialSectores;
		private System.Collections.Generic.IList<ArenaStorage> arenas;
		private System.Collections.Generic.IList<Market> markets;
		private PlayerStorage owner;
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
		
		#region SectorStorage Implementation
	
		/// <summary>
        /// Gets the SectorStorage's Fleets
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
							this.fleets = persistance.SelectBySector (this);
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
        /// Gets the SectorStorage's Fleets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Fleet> FleetsNHibernate {
			get { return this.fleets; } 
			set { this.fleets = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Planets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetStorage> Planets {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.planets == null ) {
					this.planets = new List<PlanetStorage>();
				}
				CheckCollectionSession(this.planets);
				return this.PlanetsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlanetStorage> bag = this.planets as NHibernate.Collection.Generic.PersistentGenericBag<PlanetStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.planets = new List<PlanetStorage>(bag);
                    } else {
                        this.planets = null;
                    }
                }
				if( this.planets == null ) {
					if (Transient) {
						this.planets = new List<PlanetStorage>();
					} else {
						using( IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance ()) {
							this.planets = persistance.SelectBySector (this);
						}
						if( this.planets == null ) {
							this.planets = new List<PlanetStorage>();
						}
					}
				}
				return this.planets;
#endif
			} 
			set {
				this.planets = value;
			}
		}
		
		/// <summary>
        /// Gets the SectorStorage's Planets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlanetStorage> PlanetsNHibernate {
			get { return this.planets; } 
			set { this.planets = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's SpecialSectores
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectores {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.specialSectores == null ) {
					this.specialSectores = new List<UniverseSpecialSector>();
				}
				CheckCollectionSession(this.specialSectores);
				return this.SpecialSectoresNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<UniverseSpecialSector> bag = this.specialSectores as NHibernate.Collection.Generic.PersistentGenericBag<UniverseSpecialSector>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.specialSectores = new List<UniverseSpecialSector>(bag);
                    } else {
                        this.specialSectores = null;
                    }
                }
				if( this.specialSectores == null ) {
					if (Transient) {
						this.specialSectores = new List<UniverseSpecialSector>();
					} else {
						using( IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance ()) {
							this.specialSectores = persistance.SelectBySector (this);
						}
						if( this.specialSectores == null ) {
							this.specialSectores = new List<UniverseSpecialSector>();
						}
					}
				}
				return this.specialSectores;
#endif
			} 
			set {
				this.specialSectores = value;
			}
		}
		
		/// <summary>
        /// Gets the SectorStorage's SpecialSectores NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectoresNHibernate {
			get { return this.specialSectores; } 
			set { this.specialSectores = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Arenas
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaStorage> Arenas {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.arenas == null ) {
					this.arenas = new List<ArenaStorage>();
				}
				CheckCollectionSession(this.arenas);
				return this.ArenasNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ArenaStorage> bag = this.arenas as NHibernate.Collection.Generic.PersistentGenericBag<ArenaStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.arenas = new List<ArenaStorage>(bag);
                    } else {
                        this.arenas = null;
                    }
                }
				if( this.arenas == null ) {
					if (Transient) {
						this.arenas = new List<ArenaStorage>();
					} else {
						using( IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance ()) {
							this.arenas = persistance.SelectBySector (this);
						}
						if( this.arenas == null ) {
							this.arenas = new List<ArenaStorage>();
						}
					}
				}
				return this.arenas;
#endif
			} 
			set {
				this.arenas = value;
			}
		}
		
		/// <summary>
        /// Gets the SectorStorage's Arenas NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ArenaStorage> ArenasNHibernate {
			get { return this.arenas; } 
			set { this.arenas = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Markets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Market> Markets {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.markets == null ) {
					this.markets = new List<Market>();
				}
				CheckCollectionSession(this.markets);
				return this.MarketsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Market> bag = this.markets as NHibernate.Collection.Generic.PersistentGenericBag<Market>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.markets = new List<Market>(bag);
                    } else {
                        this.markets = null;
                    }
                }
				if( this.markets == null ) {
					if (Transient) {
						this.markets = new List<Market>();
					} else {
						using( IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance ()) {
							this.markets = persistance.SelectBySector (this);
						}
						if( this.markets == null ) {
							this.markets = new List<Market>();
						}
					}
				}
				return this.markets;
#endif
			} 
			set {
				this.markets = value;
			}
		}
		
		/// <summary>
        /// Gets the SectorStorage's Markets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Market> MarketsNHibernate {
			get { return this.markets; } 
			set { this.markets = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				CheckSession(this.owner);
				return this.owner;
			}
			set { this.owner = value; }
		}
		
		/// <summary>
        /// Gets the SectorStorage's Owner
        /// </summary>
		internal virtual SpecializedPlayerStorage OwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.owner;}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				CheckSession(this.alliance);
				return this.alliance;
			}
			set { this.alliance = value; }
		}
		
		/// <summary>
        /// Gets the SectorStorage's Alliance
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceNHibernate {
			get { return (SpecializedAllianceStorage) this.alliance;}
			set { this.alliance = value; }
		}

		#endregion SectorStorage Implementation
		
	};
}
