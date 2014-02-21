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
    /// Specialized NHibernate class for Fleet
    /// </summary>
	public class SpecializedFleet : Fleet {
	
		#region Fields
		
		private System.Collections.Generic.IList<ArenaStorage> arena;
		private PlanetStorage currentPlanet;
		private Principal principalOwner;
		private SectorStorage sector;
		private PlayerStorage playerOwner;

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
		
		#region Fleet Implementation
	
		/// <summary>
        /// Gets the Fleet's Arena
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaStorage> Arena {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.arena == null ) {
					this.arena = new List<ArenaStorage>();
				}
				CheckCollectionSession(this.arena);
				return this.ArenaNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ArenaStorage> bag = this.arena as NHibernate.Collection.Generic.PersistentGenericBag<ArenaStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.arena = new List<ArenaStorage>(bag);
                    } else {
                        this.arena = null;
                    }
                }
				if( this.arena == null ) {
					if (Transient) {
						this.arena = new List<ArenaStorage>();
					} else {
						using( IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance ()) {
							this.arena = persistance.SelectByFleet (this);
						}
						if( this.arena == null ) {
							this.arena = new List<ArenaStorage>();
						}
					}
				}
				return this.arena;
#endif
			} 
			set {
				this.arena = value;
			}
		}
		
		/// <summary>
        /// Gets the Fleet's Arena NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ArenaStorage> ArenaNHibernate {
			get { return this.arena; } 
			set { this.arena = value; }
		}

		/// <summary>
        /// Gets the Fleet's CurrentPlanet
        /// </summary>
		public override PlanetStorage CurrentPlanet {
			get { 
				CheckSession(this.currentPlanet);
				return this.currentPlanet;
			}
			set { this.currentPlanet = value; }
		}
		
		/// <summary>
        /// Gets the Fleet's CurrentPlanet
        /// </summary>
		internal virtual SpecializedPlanetStorage CurrentPlanetNHibernate {
			get { return (SpecializedPlanetStorage) this.currentPlanet;}
			set { this.currentPlanet = value; }
		}

		/// <summary>
        /// Gets the Fleet's PrincipalOwner
        /// </summary>
		public override Principal PrincipalOwner {
			get { 
				CheckSession(this.principalOwner);
				return this.principalOwner;
			}
			set { this.principalOwner = value; }
		}
		
		/// <summary>
        /// Gets the Fleet's PrincipalOwner
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalOwnerNHibernate {
			get { return (SpecializedPrincipal) this.principalOwner;}
			set { this.principalOwner = value; }
		}

		/// <summary>
        /// Gets the Fleet's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				CheckSession(this.sector);
				return this.sector;
			}
			set { this.sector = value; }
		}
		
		/// <summary>
        /// Gets the Fleet's Sector
        /// </summary>
		internal virtual SpecializedSectorStorage SectorNHibernate {
			get { return (SpecializedSectorStorage) this.sector;}
			set { this.sector = value; }
		}

		/// <summary>
        /// Gets the Fleet's PlayerOwner
        /// </summary>
		public override PlayerStorage PlayerOwner {
			get { 
				CheckSession(this.playerOwner);
				return this.playerOwner;
			}
			set { this.playerOwner = value; }
		}
		
		/// <summary>
        /// Gets the Fleet's PlayerOwner
        /// </summary>
		internal virtual SpecializedPlayerStorage PlayerOwnerNHibernate {
			get { return (SpecializedPlayerStorage) this.playerOwner;}
			set { this.playerOwner = value; }
		}

		#endregion Fleet Implementation
		
	};
}
