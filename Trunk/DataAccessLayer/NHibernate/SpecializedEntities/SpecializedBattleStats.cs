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
    /// Specialized NHibernate class for BattleStats
    /// </summary>
	public class SpecializedBattleStats : BattleStats {
	
		#region Fields
		
		private PrincipalStats stats;
		private PlayerStats playerStats;

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
		
		#region BattleStats Implementation
	
		/// <summary>
        /// Gets the BattleStats's Stats
        /// </summary>
		public override PrincipalStats Stats {
			get { 
				CheckSession(this.stats);
				return this.stats;
			}
			set { this.stats = value; }
		}
		
		/// <summary>
        /// Gets the BattleStats's Stats
        /// </summary>
		internal virtual SpecializedPrincipalStats StatsNHibernate {
			get { return (SpecializedPrincipalStats) this.stats;}
			set { this.stats = value; }
		}

		/// <summary>
        /// Gets the BattleStats's PlayerStats
        /// </summary>
		public override PlayerStats PlayerStats {
			get { 
				CheckSession(this.playerStats);
				return this.playerStats;
			}
			set { this.playerStats = value; }
		}
		
		/// <summary>
        /// Gets the BattleStats's PlayerStats
        /// </summary>
		internal virtual SpecializedPlayerStats PlayerStatsNHibernate {
			get { return (SpecializedPlayerStats) this.playerStats;}
			set { this.playerStats = value; }
		}

		#endregion BattleStats Implementation
		
	};
}
