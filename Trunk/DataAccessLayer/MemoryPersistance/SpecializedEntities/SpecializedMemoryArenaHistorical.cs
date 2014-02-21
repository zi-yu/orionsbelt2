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
    /// Specialized Memory class for ArenaHistorical
    /// </summary>
	public class SpecializedMemoryArenaHistorical : ArenaHistorical {
	
		#region Fields
		
		private ArenaStorage arena;

		#endregion Fields
		
		#region ArenaHistorical Implementation
	
		/// <summary>
        /// Gets the ArenaHistorical's Arena
        /// </summary>
		public override ArenaStorage Arena {
			get { 
				return this.arena;
			}
			set { this.arena = value; }
		}

		#endregion ArenaHistorical Implementation
		
	};
}
