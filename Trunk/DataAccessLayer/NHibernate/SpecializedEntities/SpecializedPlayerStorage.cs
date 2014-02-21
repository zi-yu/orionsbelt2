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
    /// Specialized NHibernate class for PlayerStorage
    /// </summary>
	public class SpecializedPlayerStorage : PlayerStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<TimedActionStorage> actions;
		private System.Collections.Generic.IList<PlanetStorage> planets;
		private System.Collections.Generic.IList<PlanetResourceStorage> resources;
		private System.Collections.Generic.IList<SectorStorage> sector;
		private System.Collections.Generic.IList<FogOfWarStorage> discoveredUniverse;
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<UniverseSpecialSector> specialSectores;
		private System.Collections.Generic.IList<QuestStorage> quests;
		private System.Collections.Generic.IList<BidHistorical> bids;
		private System.Collections.Generic.IList<AuctionHouse> auction;
		private System.Collections.Generic.IList<ArenaStorage> arena;
		private System.Collections.Generic.IList<FriendOrFoe> myFriends;
		private System.Collections.Generic.IList<FriendOrFoe> otherFriends;
		private System.Collections.Generic.IList<Medal> medals;
		private System.Collections.Generic.IList<PrivateBoard> messages;
		private System.Collections.Generic.IList<Asset> assets;
		private System.Collections.Generic.IList<Necessity> necessities;
		private System.Collections.Generic.IList<Offering> offerings;
		private System.Collections.Generic.IList<Offering> forfeit;
		private System.Collections.Generic.IList<ForumThread> threads;
		private System.Collections.Generic.IList<ForumPost> posts;
		private System.Collections.Generic.IList<ForumReadMarking> readMarkings;
		private Principal principal;
		private AllianceStorage alliance;
		private PlayerStats stats;

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
		
		#region PlayerStorage Implementation
	
		/// <summary>
        /// Gets the PlayerStorage's Actions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<TimedActionStorage> Actions {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.actions == null ) {
					this.actions = new List<TimedActionStorage>();
				}
				CheckCollectionSession(this.actions);
				return this.ActionsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<TimedActionStorage> bag = this.actions as NHibernate.Collection.Generic.PersistentGenericBag<TimedActionStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.actions = new List<TimedActionStorage>(bag);
                    } else {
                        this.actions = null;
                    }
                }
				if( this.actions == null ) {
					if (Transient) {
						this.actions = new List<TimedActionStorage>();
					} else {
						using( ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance ()) {
							this.actions = persistance.SelectByPlayer (this);
						}
						if( this.actions == null ) {
							this.actions = new List<TimedActionStorage>();
						}
					}
				}
				return this.actions;
#endif
			} 
			set {
				this.actions = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Actions NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<TimedActionStorage> ActionsNHibernate {
			get { return this.actions; } 
			set { this.actions = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Planets
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
							this.planets = persistance.SelectByPlayer (this);
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
        /// Gets the PlayerStorage's Planets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlanetStorage> PlanetsNHibernate {
			get { return this.planets; } 
			set { this.planets = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Resources
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
							this.resources = persistance.SelectByPlayer (this);
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
        /// Gets the PlayerStorage's Resources NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlanetResourceStorage> ResourcesNHibernate {
			get { return this.resources; } 
			set { this.resources = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Sector
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<SectorStorage> Sector {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.sector == null ) {
					this.sector = new List<SectorStorage>();
				}
				CheckCollectionSession(this.sector);
				return this.SectorNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<SectorStorage> bag = this.sector as NHibernate.Collection.Generic.PersistentGenericBag<SectorStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.sector = new List<SectorStorage>(bag);
                    } else {
                        this.sector = null;
                    }
                }
				if( this.sector == null ) {
					if (Transient) {
						this.sector = new List<SectorStorage>();
					} else {
						using( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance ()) {
							this.sector = persistance.SelectByOwner (this);
						}
						if( this.sector == null ) {
							this.sector = new List<SectorStorage>();
						}
					}
				}
				return this.sector;
#endif
			} 
			set {
				this.sector = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Sector NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<SectorStorage> SectorNHibernate {
			get { return this.sector; } 
			set { this.sector = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's DiscoveredUniverse
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FogOfWarStorage> DiscoveredUniverse {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.discoveredUniverse == null ) {
					this.discoveredUniverse = new List<FogOfWarStorage>();
				}
				CheckCollectionSession(this.discoveredUniverse);
				return this.DiscoveredUniverseNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<FogOfWarStorage> bag = this.discoveredUniverse as NHibernate.Collection.Generic.PersistentGenericBag<FogOfWarStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.discoveredUniverse = new List<FogOfWarStorage>(bag);
                    } else {
                        this.discoveredUniverse = null;
                    }
                }
				if( this.discoveredUniverse == null ) {
					if (Transient) {
						this.discoveredUniverse = new List<FogOfWarStorage>();
					} else {
						using( IFogOfWarStoragePersistance persistance = Persistance.Instance.GetFogOfWarStoragePersistance ()) {
							this.discoveredUniverse = persistance.SelectByOwner (this);
						}
						if( this.discoveredUniverse == null ) {
							this.discoveredUniverse = new List<FogOfWarStorage>();
						}
					}
				}
				return this.discoveredUniverse;
#endif
			} 
			set {
				this.discoveredUniverse = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's DiscoveredUniverse NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<FogOfWarStorage> DiscoveredUniverseNHibernate {
			get { return this.discoveredUniverse; } 
			set { this.discoveredUniverse = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Fleets
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
							this.fleets = persistance.SelectByPlayerOwner (this);
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
        /// Gets the PlayerStorage's Fleets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Fleet> FleetsNHibernate {
			get { return this.fleets; } 
			set { this.fleets = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's SpecialSectores
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
							this.specialSectores = persistance.SelectByOwner (this);
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
        /// Gets the PlayerStorage's SpecialSectores NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectoresNHibernate {
			get { return this.specialSectores; } 
			set { this.specialSectores = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Quests
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<QuestStorage> Quests {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.quests == null ) {
					this.quests = new List<QuestStorage>();
				}
				CheckCollectionSession(this.quests);
				return this.QuestsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<QuestStorage> bag = this.quests as NHibernate.Collection.Generic.PersistentGenericBag<QuestStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.quests = new List<QuestStorage>(bag);
                    } else {
                        this.quests = null;
                    }
                }
				if( this.quests == null ) {
					if (Transient) {
						this.quests = new List<QuestStorage>();
					} else {
						using( IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance ()) {
							this.quests = persistance.SelectByPlayer (this);
						}
						if( this.quests == null ) {
							this.quests = new List<QuestStorage>();
						}
					}
				}
				return this.quests;
#endif
			} 
			set {
				this.quests = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Quests NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<QuestStorage> QuestsNHibernate {
			get { return this.quests; } 
			set { this.quests = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Bids
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BidHistorical> Bids {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.bids == null ) {
					this.bids = new List<BidHistorical>();
				}
				CheckCollectionSession(this.bids);
				return this.BidsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<BidHistorical> bag = this.bids as NHibernate.Collection.Generic.PersistentGenericBag<BidHistorical>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.bids = new List<BidHistorical>(bag);
                    } else {
                        this.bids = null;
                    }
                }
				if( this.bids == null ) {
					if (Transient) {
						this.bids = new List<BidHistorical>();
					} else {
						using( IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance ()) {
							this.bids = persistance.SelectByMadeBy (this);
						}
						if( this.bids == null ) {
							this.bids = new List<BidHistorical>();
						}
					}
				}
				return this.bids;
#endif
			} 
			set {
				this.bids = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Bids NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BidHistorical> BidsNHibernate {
			get { return this.bids; } 
			set { this.bids = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Auction
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AuctionHouse> Auction {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.auction == null ) {
					this.auction = new List<AuctionHouse>();
				}
				CheckCollectionSession(this.auction);
				return this.AuctionNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<AuctionHouse> bag = this.auction as NHibernate.Collection.Generic.PersistentGenericBag<AuctionHouse>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.auction = new List<AuctionHouse>(bag);
                    } else {
                        this.auction = null;
                    }
                }
				if( this.auction == null ) {
					if (Transient) {
						this.auction = new List<AuctionHouse>();
					} else {
						using( IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance ()) {
							this.auction = persistance.SelectByOwner (this);
						}
						if( this.auction == null ) {
							this.auction = new List<AuctionHouse>();
						}
					}
				}
				return this.auction;
#endif
			} 
			set {
				this.auction = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Auction NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<AuctionHouse> AuctionNHibernate {
			get { return this.auction; } 
			set { this.auction = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Arena
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
							this.arena = persistance.SelectByOwner (this);
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
        /// Gets the PlayerStorage's Arena NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ArenaStorage> ArenaNHibernate {
			get { return this.arena; } 
			set { this.arena = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's MyFriends
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FriendOrFoe> MyFriends {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.myFriends == null ) {
					this.myFriends = new List<FriendOrFoe>();
				}
				CheckCollectionSession(this.myFriends);
				return this.MyFriendsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<FriendOrFoe> bag = this.myFriends as NHibernate.Collection.Generic.PersistentGenericBag<FriendOrFoe>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.myFriends = new List<FriendOrFoe>(bag);
                    } else {
                        this.myFriends = null;
                    }
                }
				if( this.myFriends == null ) {
					if (Transient) {
						this.myFriends = new List<FriendOrFoe>();
					} else {
						using( IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance ()) {
							this.myFriends = persistance.SelectBySource (this);
						}
						if( this.myFriends == null ) {
							this.myFriends = new List<FriendOrFoe>();
						}
					}
				}
				return this.myFriends;
#endif
			} 
			set {
				this.myFriends = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's MyFriends NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<FriendOrFoe> MyFriendsNHibernate {
			get { return this.myFriends; } 
			set { this.myFriends = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's OtherFriends
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<FriendOrFoe> OtherFriends {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.otherFriends == null ) {
					this.otherFriends = new List<FriendOrFoe>();
				}
				CheckCollectionSession(this.otherFriends);
				return this.OtherFriendsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<FriendOrFoe> bag = this.otherFriends as NHibernate.Collection.Generic.PersistentGenericBag<FriendOrFoe>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.otherFriends = new List<FriendOrFoe>(bag);
                    } else {
                        this.otherFriends = null;
                    }
                }
				if( this.otherFriends == null ) {
					if (Transient) {
						this.otherFriends = new List<FriendOrFoe>();
					} else {
						using( IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance ()) {
							this.otherFriends = persistance.SelectByTarget (this);
						}
						if( this.otherFriends == null ) {
							this.otherFriends = new List<FriendOrFoe>();
						}
					}
				}
				return this.otherFriends;
#endif
			} 
			set {
				this.otherFriends = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's OtherFriends NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<FriendOrFoe> OtherFriendsNHibernate {
			get { return this.otherFriends; } 
			set { this.otherFriends = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Medals
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Medal> Medals {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.medals == null ) {
					this.medals = new List<Medal>();
				}
				CheckCollectionSession(this.medals);
				return this.MedalsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Medal> bag = this.medals as NHibernate.Collection.Generic.PersistentGenericBag<Medal>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.medals = new List<Medal>(bag);
                    } else {
                        this.medals = null;
                    }
                }
				if( this.medals == null ) {
					if (Transient) {
						this.medals = new List<Medal>();
					} else {
						using( IMedalPersistance persistance = Persistance.Instance.GetMedalPersistance ()) {
							this.medals = persistance.SelectByPlayer (this);
						}
						if( this.medals == null ) {
							this.medals = new List<Medal>();
						}
					}
				}
				return this.medals;
#endif
			} 
			set {
				this.medals = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Medals NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Medal> MedalsNHibernate {
			get { return this.medals; } 
			set { this.medals = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Messages
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrivateBoard> Messages {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.messages == null ) {
					this.messages = new List<PrivateBoard>();
				}
				CheckCollectionSession(this.messages);
				return this.MessagesNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PrivateBoard> bag = this.messages as NHibernate.Collection.Generic.PersistentGenericBag<PrivateBoard>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.messages = new List<PrivateBoard>(bag);
                    } else {
                        this.messages = null;
                    }
                }
				if( this.messages == null ) {
					if (Transient) {
						this.messages = new List<PrivateBoard>();
					} else {
						using( IPrivateBoardPersistance persistance = Persistance.Instance.GetPrivateBoardPersistance ()) {
							this.messages = persistance.SelectBySender (this);
						}
						if( this.messages == null ) {
							this.messages = new List<PrivateBoard>();
						}
					}
				}
				return this.messages;
#endif
			} 
			set {
				this.messages = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Messages NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PrivateBoard> MessagesNHibernate {
			get { return this.messages; } 
			set { this.messages = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Assets
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
							this.assets = persistance.SelectByOwner (this);
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
        /// Gets the PlayerStorage's Assets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Asset> AssetsNHibernate {
			get { return this.assets; } 
			set { this.assets = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Necessities
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Necessity> Necessities {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.necessities == null ) {
					this.necessities = new List<Necessity>();
				}
				CheckCollectionSession(this.necessities);
				return this.NecessitiesNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Necessity> bag = this.necessities as NHibernate.Collection.Generic.PersistentGenericBag<Necessity>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.necessities = new List<Necessity>(bag);
                    } else {
                        this.necessities = null;
                    }
                }
				if( this.necessities == null ) {
					if (Transient) {
						this.necessities = new List<Necessity>();
					} else {
						using( INecessityPersistance persistance = Persistance.Instance.GetNecessityPersistance ()) {
							this.necessities = persistance.SelectByCreator (this);
						}
						if( this.necessities == null ) {
							this.necessities = new List<Necessity>();
						}
					}
				}
				return this.necessities;
#endif
			} 
			set {
				this.necessities = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Necessities NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Necessity> NecessitiesNHibernate {
			get { return this.necessities; } 
			set { this.necessities = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Offerings
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Offering> Offerings {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.offerings == null ) {
					this.offerings = new List<Offering>();
				}
				CheckCollectionSession(this.offerings);
				return this.OfferingsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Offering> bag = this.offerings as NHibernate.Collection.Generic.PersistentGenericBag<Offering>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.offerings = new List<Offering>(bag);
                    } else {
                        this.offerings = null;
                    }
                }
				if( this.offerings == null ) {
					if (Transient) {
						this.offerings = new List<Offering>();
					} else {
						using( IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance ()) {
							this.offerings = persistance.SelectByDonor (this);
						}
						if( this.offerings == null ) {
							this.offerings = new List<Offering>();
						}
					}
				}
				return this.offerings;
#endif
			} 
			set {
				this.offerings = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Offerings NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Offering> OfferingsNHibernate {
			get { return this.offerings; } 
			set { this.offerings = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Forfeit
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Offering> Forfeit {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.forfeit == null ) {
					this.forfeit = new List<Offering>();
				}
				CheckCollectionSession(this.forfeit);
				return this.ForfeitNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Offering> bag = this.forfeit as NHibernate.Collection.Generic.PersistentGenericBag<Offering>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.forfeit = new List<Offering>(bag);
                    } else {
                        this.forfeit = null;
                    }
                }
				if( this.forfeit == null ) {
					if (Transient) {
						this.forfeit = new List<Offering>();
					} else {
						using( IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance ()) {
							this.forfeit = persistance.SelectByReceiver (this);
						}
						if( this.forfeit == null ) {
							this.forfeit = new List<Offering>();
						}
					}
				}
				return this.forfeit;
#endif
			} 
			set {
				this.forfeit = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Forfeit NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Offering> ForfeitNHibernate {
			get { return this.forfeit; } 
			set { this.forfeit = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Threads
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
							this.threads = persistance.SelectByOwner (this);
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
        /// Gets the PlayerStorage's Threads NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumThread> ThreadsNHibernate {
			get { return this.threads; } 
			set { this.threads = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Posts
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
							this.posts = persistance.SelectByOwner (this);
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
        /// Gets the PlayerStorage's Posts NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumPost> PostsNHibernate {
			get { return this.posts; } 
			set { this.posts = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's ReadMarkings
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
							this.readMarkings = persistance.SelectByPlayer (this);
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
        /// Gets the PlayerStorage's ReadMarkings NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ForumReadMarking> ReadMarkingsNHibernate {
			get { return this.readMarkings; } 
			set { this.readMarkings = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				CheckSession(this.principal);
				return this.principal;
			}
			set { this.principal = value; }
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Principal
        /// </summary>
		internal virtual SpecializedPrincipal PrincipalNHibernate {
			get { return (SpecializedPrincipal) this.principal;}
			set { this.principal = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				CheckSession(this.alliance);
				return this.alliance;
			}
			set { this.alliance = value; }
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Alliance
        /// </summary>
		internal virtual SpecializedAllianceStorage AllianceNHibernate {
			get { return (SpecializedAllianceStorage) this.alliance;}
			set { this.alliance = value; }
		}

		/// <summary>
        /// Gets the PlayerStorage's Stats
        /// </summary>
		public override PlayerStats Stats {
			get { 
				CheckSession(this.stats);
				return this.stats;
			}
			set { this.stats = value; }
		}
		
		/// <summary>
        /// Gets the PlayerStorage's Stats
        /// </summary>
		internal virtual SpecializedPlayerStats StatsNHibernate {
			get { return (SpecializedPlayerStats) this.stats;}
			set { this.stats = value; }
		}

		#endregion PlayerStorage Implementation
		
	};
}
