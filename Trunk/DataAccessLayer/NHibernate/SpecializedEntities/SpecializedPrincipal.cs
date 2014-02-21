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
    /// Specialized NHibernate class for Principal
    /// </summary>
	public class SpecializedPrincipal : Principal {
	
		#region Fields
		
		private System.Collections.Generic.IList<PrincipalTournament> tournaments;
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlayerStorage> player;
		private System.Collections.Generic.IList<Medal> medals;
		private System.Collections.Generic.IList<Campaign> createdCampaigns;
		private System.Collections.Generic.IList<CampaignStatus> campaigns;
		private System.Collections.Generic.IList<BonusCard> usedCards;
		private System.Collections.Generic.IList<Promotion> promotions;
		private System.Collections.Generic.IList<ActivatedPromotion> activePromotions;
		private System.Collections.Generic.IList<ExceptionInfo> exceptions;
		private TeamStorage team;

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
		
		#region Principal Implementation
	
		/// <summary>
        /// Gets the Principal's Tournaments
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PrincipalTournament> Tournaments {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.tournaments == null ) {
					this.tournaments = new List<PrincipalTournament>();
				}
				CheckCollectionSession(this.tournaments);
				return this.TournamentsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament> bag = this.tournaments as NHibernate.Collection.Generic.PersistentGenericBag<PrincipalTournament>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.tournaments = new List<PrincipalTournament>(bag);
                    } else {
                        this.tournaments = null;
                    }
                }
				if( this.tournaments == null ) {
					if (Transient) {
						this.tournaments = new List<PrincipalTournament>();
					} else {
						using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance ()) {
							this.tournaments = persistance.SelectByPrincipal (this);
						}
						if( this.tournaments == null ) {
							this.tournaments = new List<PrincipalTournament>();
						}
					}
				}
				return this.tournaments;
#endif
			} 
			set {
				this.tournaments = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Tournaments NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PrincipalTournament> TournamentsNHibernate {
			get { return this.tournaments; } 
			set { this.tournaments = value; }
		}

		/// <summary>
        /// Gets the Principal's Fleets
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
							this.fleets = persistance.SelectByPrincipalOwner (this);
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
        /// Gets the Principal's Fleets NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Fleet> FleetsNHibernate {
			get { return this.fleets; } 
			set { this.fleets = value; }
		}

		/// <summary>
        /// Gets the Principal's Player
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerStorage> Player {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.player == null ) {
					this.player = new List<PlayerStorage>();
				}
				CheckCollectionSession(this.player);
				return this.PlayerNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlayerStorage> bag = this.player as NHibernate.Collection.Generic.PersistentGenericBag<PlayerStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.player = new List<PlayerStorage>(bag);
                    } else {
                        this.player = null;
                    }
                }
				if( this.player == null ) {
					if (Transient) {
						this.player = new List<PlayerStorage>();
					} else {
						using( IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance ()) {
							this.player = persistance.SelectByPrincipal (this);
						}
						if( this.player == null ) {
							this.player = new List<PlayerStorage>();
						}
					}
				}
				return this.player;
#endif
			} 
			set {
				this.player = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Player NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlayerStorage> PlayerNHibernate {
			get { return this.player; } 
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the Principal's Medals
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
							this.medals = persistance.SelectByPrincipal (this);
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
        /// Gets the Principal's Medals NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Medal> MedalsNHibernate {
			get { return this.medals; } 
			set { this.medals = value; }
		}

		/// <summary>
        /// Gets the Principal's CreatedCampaigns
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Campaign> CreatedCampaigns {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.createdCampaigns == null ) {
					this.createdCampaigns = new List<Campaign>();
				}
				CheckCollectionSession(this.createdCampaigns);
				return this.CreatedCampaignsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Campaign> bag = this.createdCampaigns as NHibernate.Collection.Generic.PersistentGenericBag<Campaign>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.createdCampaigns = new List<Campaign>(bag);
                    } else {
                        this.createdCampaigns = null;
                    }
                }
				if( this.createdCampaigns == null ) {
					if (Transient) {
						this.createdCampaigns = new List<Campaign>();
					} else {
						using( ICampaignPersistance persistance = Persistance.Instance.GetCampaignPersistance ()) {
							this.createdCampaigns = persistance.SelectByPrincipal (this);
						}
						if( this.createdCampaigns == null ) {
							this.createdCampaigns = new List<Campaign>();
						}
					}
				}
				return this.createdCampaigns;
#endif
			} 
			set {
				this.createdCampaigns = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's CreatedCampaigns NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Campaign> CreatedCampaignsNHibernate {
			get { return this.createdCampaigns; } 
			set { this.createdCampaigns = value; }
		}

		/// <summary>
        /// Gets the Principal's Campaigns
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<CampaignStatus> Campaigns {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.campaigns == null ) {
					this.campaigns = new List<CampaignStatus>();
				}
				CheckCollectionSession(this.campaigns);
				return this.CampaignsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus> bag = this.campaigns as NHibernate.Collection.Generic.PersistentGenericBag<CampaignStatus>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.campaigns = new List<CampaignStatus>(bag);
                    } else {
                        this.campaigns = null;
                    }
                }
				if( this.campaigns == null ) {
					if (Transient) {
						this.campaigns = new List<CampaignStatus>();
					} else {
						using( ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance ()) {
							this.campaigns = persistance.SelectByPrincipal (this);
						}
						if( this.campaigns == null ) {
							this.campaigns = new List<CampaignStatus>();
						}
					}
				}
				return this.campaigns;
#endif
			} 
			set {
				this.campaigns = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Campaigns NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<CampaignStatus> CampaignsNHibernate {
			get { return this.campaigns; } 
			set { this.campaigns = value; }
		}

		/// <summary>
        /// Gets the Principal's UsedCards
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BonusCard> UsedCards {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.usedCards == null ) {
					this.usedCards = new List<BonusCard>();
				}
				CheckCollectionSession(this.usedCards);
				return this.UsedCardsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<BonusCard> bag = this.usedCards as NHibernate.Collection.Generic.PersistentGenericBag<BonusCard>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.usedCards = new List<BonusCard>(bag);
                    } else {
                        this.usedCards = null;
                    }
                }
				if( this.usedCards == null ) {
					if (Transient) {
						this.usedCards = new List<BonusCard>();
					} else {
						using( IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance ()) {
							this.usedCards = persistance.SelectByUsedBy (this);
						}
						if( this.usedCards == null ) {
							this.usedCards = new List<BonusCard>();
						}
					}
				}
				return this.usedCards;
#endif
			} 
			set {
				this.usedCards = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's UsedCards NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BonusCard> UsedCardsNHibernate {
			get { return this.usedCards; } 
			set { this.usedCards = value; }
		}

		/// <summary>
        /// Gets the Principal's Promotions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Promotion> Promotions {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.promotions == null ) {
					this.promotions = new List<Promotion>();
				}
				CheckCollectionSession(this.promotions);
				return this.PromotionsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<Promotion> bag = this.promotions as NHibernate.Collection.Generic.PersistentGenericBag<Promotion>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.promotions = new List<Promotion>(bag);
                    } else {
                        this.promotions = null;
                    }
                }
				if( this.promotions == null ) {
					if (Transient) {
						this.promotions = new List<Promotion>();
					} else {
						using( IPromotionPersistance persistance = Persistance.Instance.GetPromotionPersistance ()) {
							this.promotions = persistance.SelectByOwner (this);
						}
						if( this.promotions == null ) {
							this.promotions = new List<Promotion>();
						}
					}
				}
				return this.promotions;
#endif
			} 
			set {
				this.promotions = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Promotions NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<Promotion> PromotionsNHibernate {
			get { return this.promotions; } 
			set { this.promotions = value; }
		}

		/// <summary>
        /// Gets the Principal's ActivePromotions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ActivatedPromotion> ActivePromotions {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.activePromotions == null ) {
					this.activePromotions = new List<ActivatedPromotion>();
				}
				CheckCollectionSession(this.activePromotions);
				return this.ActivePromotionsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ActivatedPromotion> bag = this.activePromotions as NHibernate.Collection.Generic.PersistentGenericBag<ActivatedPromotion>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.activePromotions = new List<ActivatedPromotion>(bag);
                    } else {
                        this.activePromotions = null;
                    }
                }
				if( this.activePromotions == null ) {
					if (Transient) {
						this.activePromotions = new List<ActivatedPromotion>();
					} else {
						using( IActivatedPromotionPersistance persistance = Persistance.Instance.GetActivatedPromotionPersistance ()) {
							this.activePromotions = persistance.SelectByPrincipal (this);
						}
						if( this.activePromotions == null ) {
							this.activePromotions = new List<ActivatedPromotion>();
						}
					}
				}
				return this.activePromotions;
#endif
			} 
			set {
				this.activePromotions = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's ActivePromotions NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ActivatedPromotion> ActivePromotionsNHibernate {
			get { return this.activePromotions; } 
			set { this.activePromotions = value; }
		}

		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ExceptionInfo> Exceptions {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.exceptions == null ) {
					this.exceptions = new List<ExceptionInfo>();
				}
				CheckCollectionSession(this.exceptions);
				return this.ExceptionsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<ExceptionInfo> bag = this.exceptions as NHibernate.Collection.Generic.PersistentGenericBag<ExceptionInfo>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.exceptions = new List<ExceptionInfo>(bag);
                    } else {
                        this.exceptions = null;
                    }
                }
				if( this.exceptions == null ) {
					if (Transient) {
						this.exceptions = new List<ExceptionInfo>();
					} else {
						using( IExceptionInfoPersistance persistance = Persistance.Instance.GetExceptionInfoPersistance ()) {
							this.exceptions = persistance.SelectByPrincipal (this);
						}
						if( this.exceptions == null ) {
							this.exceptions = new List<ExceptionInfo>();
						}
					}
				}
				return this.exceptions;
#endif
			} 
			set {
				this.exceptions = value;
			}
		}
		
		/// <summary>
        /// Gets the Principal's Exceptions NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<ExceptionInfo> ExceptionsNHibernate {
			get { return this.exceptions; } 
			set { this.exceptions = value; }
		}

		/// <summary>
        /// Gets the Principal's Team
        /// </summary>
		public override TeamStorage Team {
			get { 
				CheckSession(this.team);
				return this.team;
			}
			set { this.team = value; }
		}
		
		/// <summary>
        /// Gets the Principal's Team
        /// </summary>
		internal virtual SpecializedTeamStorage TeamNHibernate {
			get { return (SpecializedTeamStorage) this.team;}
			set { this.team = value; }
		}

		#endregion Principal Implementation
		
	};
}
