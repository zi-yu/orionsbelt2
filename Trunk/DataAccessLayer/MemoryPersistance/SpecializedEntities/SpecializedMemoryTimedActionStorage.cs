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
    /// Specialized Memory class for TimedActionStorage
    /// </summary>
	public class SpecializedMemoryTimedActionStorage : TimedActionStorage {
	
		#region Fields
		
		private PlayerStorage player;
		private Battle battle;

		#endregion Fields
		
		#region TimedActionStorage Implementation
	
		/// <summary>
        /// Gets the TimedActionStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				return this.player;
			}
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the TimedActionStorage's Battle
        /// </summary>
		public override Battle Battle {
			get { 
				return this.battle;
			}
			set { this.battle = value; }
		}

		#endregion TimedActionStorage Implementation
		
	};
}
