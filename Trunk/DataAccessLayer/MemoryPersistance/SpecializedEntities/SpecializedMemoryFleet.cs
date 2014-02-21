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
    /// Specialized Memory class for Fleet
    /// </summary>
	public class SpecializedMemoryFleet : Fleet {
	
		#region Fields
		
		private System.Collections.Generic.IList<ArenaStorage> arena;
		private PlanetStorage currentPlanet;
		private Principal principalOwner;
		private SectorStorage sector;
		private PlayerStorage playerOwner;

		#endregion Fields
		
		#region Fleet Implementation
	
		/// <summary>
        /// Gets the Fleet's Arena
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ArenaStorage> Arena {
			get {
				if( this.arena == null ) {
					this.arena = new List<ArenaStorage>();
				}
				return this.arena;
			} 
			set {
				this.arena = value;
			}
		}

		/// <summary>
        /// Gets the Fleet's CurrentPlanet
        /// </summary>
		public override PlanetStorage CurrentPlanet {
			get { 
				return this.currentPlanet;
			}
			set { this.currentPlanet = value; }
		}

		/// <summary>
        /// Gets the Fleet's PrincipalOwner
        /// </summary>
		public override Principal PrincipalOwner {
			get { 
				return this.principalOwner;
			}
			set { this.principalOwner = value; }
		}

		/// <summary>
        /// Gets the Fleet's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				return this.sector;
			}
			set { this.sector = value; }
		}

		/// <summary>
        /// Gets the Fleet's PlayerOwner
        /// </summary>
		public override PlayerStorage PlayerOwner {
			get { 
				return this.playerOwner;
			}
			set { this.playerOwner = value; }
		}

		#endregion Fleet Implementation
		
	};
}
