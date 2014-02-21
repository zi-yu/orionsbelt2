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
    /// Specialized Memory class for UniverseSpecialSector
    /// </summary>
	public class SpecializedMemoryUniverseSpecialSector : UniverseSpecialSector {
	
		#region Fields
		
		private PlayerStorage owner;
		private SectorStorage sector;

		#endregion Fields
		
		#region UniverseSpecialSector Implementation
	
		/// <summary>
        /// Gets the UniverseSpecialSector's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the UniverseSpecialSector's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				return this.sector;
			}
			set { this.sector = value; }
		}

		#endregion UniverseSpecialSector Implementation
		
	};
}
