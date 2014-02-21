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
    /// Specialized Memory class for BattleStats
    /// </summary>
	public class SpecializedMemoryBattleStats : BattleStats {
	
		#region Fields
		
		private PrincipalStats stats;
		private PlayerStats playerStats;

		#endregion Fields
		
		#region BattleStats Implementation
	
		/// <summary>
        /// Gets the BattleStats's Stats
        /// </summary>
		public override PrincipalStats Stats {
			get { 
				return this.stats;
			}
			set { this.stats = value; }
		}

		/// <summary>
        /// Gets the BattleStats's PlayerStats
        /// </summary>
		public override PlayerStats PlayerStats {
			get { 
				return this.playerStats;
			}
			set { this.playerStats = value; }
		}

		#endregion BattleStats Implementation
		
	};
}
