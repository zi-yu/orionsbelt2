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
    /// Specialized NHibernate class for PlayerStats
    /// </summary>
	public class SpecializedPlayerStats : PlayerStats {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerStorage> player;
		private System.Collections.Generic.IList<BattleStats> battleStats;

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
		
		#region PlayerStats Implementation
	
		/// <summary>
        /// Gets the PlayerStats's Player
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
							this.player = persistance.SelectByStats (this);
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
        /// Gets the PlayerStats's Player NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<PlayerStorage> PlayerNHibernate {
			get { return this.player; } 
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the PlayerStats's BattleStats
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BattleStats> BattleStats {
			get {
#if NHIBERNATE_COLLECTIONS
				if( this.battleStats == null ) {
					this.battleStats = new List<BattleStats>();
				}
				CheckCollectionSession(this.battleStats);
				return this.BattleStatsNHibernate;
#else
				NHibernate.Collection.Generic.PersistentGenericBag<BattleStats> bag = this.battleStats as NHibernate.Collection.Generic.PersistentGenericBag<BattleStats>;
                if (bag != null) {
                    if (NHibernateUtilities.IsCollectionOk(bag)) {
                        // loose the lazyness
                        this.battleStats = new List<BattleStats>(bag);
                    } else {
                        this.battleStats = null;
                    }
                }
				if( this.battleStats == null ) {
					if (Transient) {
						this.battleStats = new List<BattleStats>();
					} else {
						using( IBattleStatsPersistance persistance = Persistance.Instance.GetBattleStatsPersistance ()) {
							this.battleStats = persistance.SelectByPlayerStats (this);
						}
						if( this.battleStats == null ) {
							this.battleStats = new List<BattleStats>();
						}
					}
				}
				return this.battleStats;
#endif
			} 
			set {
				this.battleStats = value;
			}
		}
		
		/// <summary>
        /// Gets the PlayerStats's BattleStats NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BattleStats> BattleStatsNHibernate {
			get { return this.battleStats; } 
			set { this.battleStats = value; }
		}

		#endregion PlayerStats Implementation
		
	};
}
