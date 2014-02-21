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
    /// Specialized Memory class for PlayerStats
    /// </summary>
	public class SpecializedMemoryPlayerStats : PlayerStats {
	
		#region Fields
		
		private System.Collections.Generic.IList<PlayerStorage> player;
		private System.Collections.Generic.IList<BattleStats> battleStats;

		#endregion Fields
		
		#region PlayerStats Implementation
	
		/// <summary>
        /// Gets the PlayerStats's Player
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlayerStorage> Player {
			get {
				if( this.player == null ) {
					this.player = new List<PlayerStorage>();
				}
				return this.player;
			} 
			set {
				this.player = value;
			}
		}

		/// <summary>
        /// Gets the PlayerStats's BattleStats
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BattleStats> BattleStats {
			get {
				if( this.battleStats == null ) {
					this.battleStats = new List<BattleStats>();
				}
				return this.battleStats;
			} 
			set {
				this.battleStats = value;
			}
		}

		#endregion PlayerStats Implementation
		
	};
}
