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
    /// Specialized Memory class for QuestStorage
    /// </summary>
	public class SpecializedMemoryQuestStorage : QuestStorage {
	
		#region Fields
		
		private PlayerStorage player;

		#endregion Fields
		
		#region QuestStorage Implementation
	
		/// <summary>
        /// Gets the QuestStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				return this.player;
			}
			set { this.player = value; }
		}

		#endregion QuestStorage Implementation
		
	};
}
