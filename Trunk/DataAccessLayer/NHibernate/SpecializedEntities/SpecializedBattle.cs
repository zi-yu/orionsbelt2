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
    /// Specialized NHibernate class for Battle
    /// </summary>
	public class SpecializedBattle : Battle {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerBattleInformation> playerInformation;
		private System.Collections.Generic.IList<BattleExtention> battleExtension;
		private System.Collections.Generic.IList<TimedActionStorage> timedAction;
		private System.Collections.Generic.IList<CampaignStatus> campaigns;
		private Tournament tournament;
		private PlayersGroupStorage group;

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
		
		#region Battle Implementation
	
		/// <summary>
        /// Gets the Battle's PlayerInformation
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerBattleInformation> PlayerInformation {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.playerInformation == null ) {
					this.playerInformation = new List<PlayerBattleInformation>();
				}
				CheckCollectionSession(this.playerInformation);
				return this.PlayerInformationNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<PlayerBattleInformation> bag = this.playerInformation as NHibernate.Collection.Generic.PersistentGenericBag<PlayerBattleInformation>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.playerInformation = new List<PlayerBattleInformation>(bag);
                    } else {
                        this.playerInformation = null;
                    }
                }
				if( this.playerInformation == null ) {
					if (Transient) {
						this.playerInformation = new List<PlayerBattleInformation>();
					} else {
						using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance ()) {
							this.playerInformation = persistance.SelectByBattle (this);
						}
						if( this.playerInformation == null ) {
							this.playerInformation = new List<PlayerBattleInformation>();
						}
					}
				}
				return this.playerInformation;
#endif
			} 
			set {
				this.playerInformation = value;
			}
		}
		
		/// <summary>
        /// Gets the Battle's PlayerInformation NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlayerBattleInformation> PlayerInformationNHibernate {
			get { return this.playerInformation; } 
			set { this.playerInformation = value; }
		}

		/// <summary>
        /// Gets the Battle's BattleExtension
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BattleExtention> BattleExtension {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.battleExtension == null ) {
					this.battleExtension = new List<BattleExtention>();
				}
				CheckCollectionSession(this.battleExtension);
				return this.BattleExtensionNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<BattleExtention> bag = this.battleExtension as NHibernate.Collection.Generic.PersistentGenericBag<BattleExtention>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.battleExtension = new List<BattleExtention>(bag);
                    } else {
                        this.battleExtension = null;
                    }
                }
				if( this.battleExtension == null ) {
					if (Transient) {
						this.battleExtension = new List<BattleExtention>();
					} else {
						using( IBattleExtentionPersistance persistance = Persistance.Instance.GetBattleExtentionPersistance ()) {
							this.battleExtension = persistance.SelectByBattle (this);
						}
						if( this.battleExtension == null ) {
							this.battleExtension = new List<BattleExtention>();
						}
					}
				}
				return this.battleExtension;
#endif
			} 
			set {
				this.battleExtension = value;
			}
		}
		
		/// <summary>
        /// Gets the Battle's BattleExtension NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BattleExtention> BattleExtensionNHibernate {
			get { return this.battleExtension; } 
			set { this.battleExtension = value; }
		}

		/// <summary>
        /// Gets the Battle's TimedAction
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<TimedActionStorage> TimedAction {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.timedAction == null ) {
					this.timedAction = new List<TimedActionStorage>();
				}
				CheckCollectionSession(this.timedAction);
				return this.TimedActionNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<TimedActionStorage> bag = this.timedAction as NHibernate.Collection.Generic.PersistentGenericBag<TimedActionStorage>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.timedAction = new List<TimedActionStorage>(bag);
                    } else {
                        this.timedAction = null;
                    }
                }
				if( this.timedAction == null ) {
					if (Transient) {
						this.timedAction = new List<TimedActionStorage>();
					} else {
						using( ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance ()) {
							this.timedAction = persistance.SelectByBattle (this);
						}
						if( this.timedAction == null ) {
							this.timedAction = new List<TimedActionStorage>();
						}
					}
				}
				return this.timedAction;
#endif
			} 
			set {
				this.timedAction = value;
			}
		}
		
		/// <summary>
        /// Gets the Battle's TimedAction NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<TimedActionStorage> TimedActionNHibernate {
			get { return this.timedAction; } 
			set { this.timedAction = value; }
		}

		/// <summary>
        /// Gets the Battle's Campaigns
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
							this.campaigns = persistance.SelectByBattle (this);
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
        /// Gets the Battle's Campaigns NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<CampaignStatus> CampaignsNHibernate {
			get { return this.campaigns; } 
			set { this.campaigns = value; }
		}

		/// <summary>
        /// Gets the Battle's Tournament
        /// </summary>
		public override Tournament Tournament {
			get { 
				CheckSession(this.tournament);
				return this.tournament;
			}
			set { this.tournament = value; }
		}
		
		/// <summary>
        /// Gets the Battle's Tournament
        /// </summary>
		internal virtual SpecializedTournament TournamentNHibernate {
			get { return (SpecializedTournament) this.tournament;}
			set { this.tournament = value; }
		}

		/// <summary>
        /// Gets the Battle's Group
        /// </summary>
		public override PlayersGroupStorage Group {
			get { 
				CheckSession(this.group);
				return this.group;
			}
			set { this.group = value; }
		}
		
		/// <summary>
        /// Gets the Battle's Group
        /// </summary>
		internal virtual SpecializedPlayersGroupStorage GroupNHibernate {
			get { return (SpecializedPlayersGroupStorage) this.group;}
			set { this.group = value; }
		}

		#endregion Battle Implementation
		
	};
}
