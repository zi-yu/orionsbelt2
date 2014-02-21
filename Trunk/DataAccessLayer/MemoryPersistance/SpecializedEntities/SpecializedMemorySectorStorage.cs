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
    /// Specialized Memory class for SectorStorage
    /// </summary>
	public class SpecializedMemorySectorStorage : SectorStorage {
	
		#region Fields
		
		private System.Collections.Generic.IList<Fleet> fleets;
		private System.Collections.Generic.IList<PlanetStorage> planets;
		private System.Collections.Generic.IList<UniverseSpecialSector> specialSectores;
		private System.Collections.Generic.IList<ArenaStorage> arenas;
		private System.Collections.Generic.IList<Market> markets;
		private PlayerStorage owner;
		private AllianceStorage alliance;

		#endregion Fields
		
		#region SectorStorage Implementation
	
		/// <summary>
        /// Gets the SectorStorage's Fleets
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
        /// Gets the SectorStorage's Planets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<PlanetStorage> Planets {
			get {
				if( this.planets == null ) {
					this.planets = new List<PlanetStorage>();
				}
				return this.planets;
			} 
			set {
				this.planets = value;
			}
		}

		/// <summary>
        /// Gets the SectorStorage's SpecialSectores
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<UniverseSpecialSector> SpecialSectores {
			get {
				if( this.specialSectores == null ) {
					this.specialSectores = new List<UniverseSpecialSector>();
				}
				return this.specialSectores;
			} 
			set {
				this.specialSectores = value;
			}
		}

		/// <summary>
        /// Gets the SectorStorage's Arenas
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaStorage> Arenas {
			get {
				if( this.arenas == null ) {
					this.arenas = new List<ArenaStorage>();
				}
				return this.arenas;
			} 
			set {
				this.arenas = value;
			}
		}

		/// <summary>
        /// Gets the SectorStorage's Markets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Market> Markets {
			get {
				if( this.markets == null ) {
					this.markets = new List<Market>();
				}
				return this.markets;
			} 
			set {
				this.markets = value;
			}
		}

		/// <summary>
        /// Gets the SectorStorage's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the SectorStorage's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				return this.alliance;
			}
			set { this.alliance = value; }
		}

		#endregion SectorStorage Implementation
		
	};
}
