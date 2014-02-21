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
    /// Specialized Memory class for PrincipalStats
    /// </summary>
	public class SpecializedMemoryPrincipalStats : PrincipalStats {
	
		#region Fields
		
		private System.Collections.Generic.IList<BattleStats> battleStats;

		#endregion Fields
		
		#region PrincipalStats Implementation
	
		/// <summary>
        /// Gets the PrincipalStats's BattleStats
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

		#endregion PrincipalStats Implementation
		
	};
}
