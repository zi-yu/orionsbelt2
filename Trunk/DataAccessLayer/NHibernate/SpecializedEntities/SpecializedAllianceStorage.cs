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
    /// Specialized NHibernate class for AllianceStorage
    /// </summary>
	public class SpecializedAllianceStorage : AllianceStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerStorage> players;
		private System.Collections.Generic.IList<AllianceDiplomacy> diplomacyA;
		private System.Collections.Generic.IList<AllianceDiplomacy> diplomacyB;
		private System.Collections.Generic.IList<SectorStorage> sector;
		private System.Collections.Generic.IList<Asset> assets;
		private System.Collections.Generic.IList<Necessity> necessities;
		private System.Collections.Generic.IList<Offering> offerings;

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
		
		#region AllianceStorage Implementation
	
		/// <summary>
        /// Gets the AllianceStorage's Players
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerStorage> Players {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.players == null ) {
					this.players = new List<PlayerStorage>();
				}
				CheckCollectionSession(this.players);
				return this.PlayersNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlayerStorage> bag = this.players as NHibernate.Collection.Generic.PersistentGenericBag<PlayerStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.players = new List<PlayerStorage>(bag);
                    } else {
                        this.players = null;
                    }
                }
				if( this.players == null ) {
					if (Transient) {
						this.players = new List<PlayerStorage>();
					} else {
						using( IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance ()) {
							this.players = persistance.SelectByAlliance (this);
						}
						if( this.players == null ) {
							this.players = new List<PlayerStorage>();
						}
					}
				}
				return this.players;
#endif
			} 
			set {
				this.players = value;
			}
		}
		
		/// <summary>
        /// Gets the AllianceStorage's Players NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlayerStorage> PlayersNHibernate {
			get { return this.players; } 
			set { this.players = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyA
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyA {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.diplomacyA == null ) {
					this.diplomacyA = new List<AllianceDiplomacy>();
				}
				CheckCollectionSession(this.diplomacyA);
				return this.DiplomacyANHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<AllianceDiplomacy> bag = this.diplomacyA as NHibernate.Collection.Generic.PersistentGenericBag<AllianceDiplomacy>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.diplomacyA = new List<AllianceDiplomacy>(bag);
                    } else {
                        this.diplomacyA = null;
                    }
                }
				if( this.diplomacyA == null ) {
					if (Transient) {
						this.diplomacyA = new List<AllianceDiplomacy>();
					} else {
						using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance ()) {
							this.diplomacyA = persistance.SelectByAllianceA (this);
						}
						if( this.diplomacyA == null ) {
							this.diplomacyA = new List<AllianceDiplomacy>();
						}
					}
				}
				return this.diplomacyA;
#endif
			} 
			set {
				this.diplomacyA = value;
			}
		}
		
		/// <summary>
        /// Gets the AllianceStorage's DiplomacyA NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyANHibernate {
			get { return this.diplomacyA; } 
			set { this.diplomacyA = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's DiplomacyB
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyB {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.diplomacyB == null ) {
					this.diplomacyB = new List<AllianceDiplomacy>();
				}
				CheckCollectionSession(this.diplomacyB);
				return this.DiplomacyBNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<AllianceDiplomacy> bag = this.diplomacyB as NHibernate.Collection.Generic.PersistentGenericBag<AllianceDiplomacy>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.diplomacyB = new List<AllianceDiplomacy>(bag);
                    } else {
                        this.diplomacyB = null;
                    }
                }
				if( this.diplomacyB == null ) {
					if (Transient) {
						this.diplomacyB = new List<AllianceDiplomacy>();
					} else {
						using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance ()) {
							this.diplomacyB = persistance.SelectByAllianceB (this);
						}
						if( this.diplomacyB == null ) {
							this.diplomacyB = new List<AllianceDiplomacy>();
						}
					}
				}
				return this.diplomacyB;
#endif
			} 
			set {
				this.diplomacyB = value;
			}
		}
		
		/// <summary>
        /// Gets the AllianceStorage's DiplomacyB NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<AllianceDiplomacy> DiplomacyBNHibernate {
			get { return this.diplomacyB; } 
			set { this.diplomacyB = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's Sector
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
							this.sector = persistance.SelectByAlliance (this);
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
        /// Gets the AllianceStorage's Sector NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<SectorStorage> SectorNHibernate {
			get { return this.sector; } 
			set { this.sector = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's Assets
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
							this.assets = persistance.SelectByAlliance (this);
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
        /// Gets the AllianceStorage's Assets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Asset> AssetsNHibernate {
			get { return this.assets; } 
			set { this.assets = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's Necessities
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
							this.necessities = persistance.SelectByAlliance (this);
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
        /// Gets the AllianceStorage's Necessities NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Necessity> NecessitiesNHibernate {
			get { return this.necessities; } 
			set { this.necessities = value; }
		}

		/// <summary>
        /// Gets the AllianceStorage's Offerings
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
							this.offerings = persistance.SelectByAlliance (this);
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
        /// Gets the AllianceStorage's Offerings NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Offering> OfferingsNHibernate {
			get { return this.offerings; } 
			set { this.offerings = value; }
		}

		#endregion AllianceStorage Implementation
		
	};
}
