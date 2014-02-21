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
    /// Specialized Memory class for PlanetStorage
    /// </summary>
	public class SpecializedMemoryPlanetStorage : PlanetStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlanetResourceStorage> resources;
		private PlayerStorage player;
		private SectorStorage sector;

		#endregion Fields
		
		#region PlanetStorage Implementation
	
		/// <summary>
        /// Gets the PlanetStorage's Fleets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Fleet> Fleets {
			get {
				if( this.fleets == null ) {
					this.fleets = new List<Fleet>();
				}
				return this.fleets;
			} 
			set {
				this.fleets = value;
			}
		}

		/// <summary>
        /// Gets the PlanetStorage's Resources
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetResourceStorage> Resources {
			get {
				if( this.resources == null ) {
					this.resources = new List<PlanetResourceStorage>();
				}
				return this.resources;
			} 
			set {
				this.resources = value;
			}
		}

		/// <summary>
        /// Gets the PlanetStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				return this.player;
			}
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the PlanetStorage's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				return this.sector;
			}
			set { this.sector = value; }
		}

		#endregion PlanetStorage Implementation
		
	};
}
