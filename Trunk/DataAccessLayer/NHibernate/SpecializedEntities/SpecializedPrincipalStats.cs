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
    /// Specialized NHibernate class for PrincipalStats
    /// </summary>
	public class SpecializedPrincipalStats : PrincipalStats {
	
		#region Fields
		
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
		
		#region PrincipalStats Implementation
	
		/// <summary>
        /// Gets the PrincipalStats's BattleStats
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
							this.battleStats = persistance.SelectByStats (this);
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
        /// Gets the PrincipalStats's BattleStats NHibernate container
        /// </summary>
		[XmlIgnore()]
		internal virtual System.Collections.Generic.IList<BattleStats> BattleStatsNHibernate {
			get { return this.battleStats; } 
			set { this.battleStats = value; }
		}

		#endregion PrincipalStats Implementation
		
	};
}
