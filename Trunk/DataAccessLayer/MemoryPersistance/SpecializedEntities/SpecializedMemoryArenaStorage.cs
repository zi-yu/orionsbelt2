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
    /// Specialized Memory class for ArenaStorage
    /// </summary>
	public class SpecializedMemoryArenaStorage : ArenaStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<ArenaHistorical> historical;
		private Fleet fleet;
		private PlayerStorage owner;
		private SectorStorage sector;

		#endregion Fields
		
		#region ArenaStorage Implementation
	
		/// <summary>
        /// Gets the ArenaStorage's Historical
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaHistorical> Historical {
			get {
				if( this.historical == null ) {
					this.historical = new List<ArenaHistorical>();
				}
				return this.historical;
			} 
			set {
				this.historical = value;
			}
		}

		/// <summary>
        /// Gets the ArenaStorage's Fleet
        /// </summary>
		public override Fleet Fleet {
			get { 
				return this.fleet;
			}
			set { this.fleet = value; }
		}

		/// <summary>
        /// Gets the ArenaStorage's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the ArenaStorage's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				return this.sector;
			}
			set { this.sector = value; }
		}

		#endregion ArenaStorage Implementation
		
	};
}
