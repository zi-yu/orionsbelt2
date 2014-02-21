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
    /// Specialized Memory class for BattleExtention
    /// </summary>
	public class SpecializedMemoryBattleExtention : BattleExtention {
	
		#region Fields
		
		private Battle battle;

		#endregion Fields
		
		#region BattleExtention Implementation
	
		/// <summary>
        /// Gets the BattleExtention's Battle
        /// </summary>
		public override Battle Battle {
			get { 
				return this.battle;
			}
			set { this.battle = value; }
		}

		#endregion BattleExtention Implementation
		
	};
}
