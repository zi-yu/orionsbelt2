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
    /// Specialized Memory class for PlanetResourceStorage
    /// </summary>
	public class SpecializedMemoryPlanetResourceStorage : PlanetResourceStorage {
	
		#region Fields
		
		private PlanetStorage planet;
		private PlayerStorage player;

		#endregion Fields
		
		#region PlanetResourceStorage Implementation
	
		/// <summary>
        /// Gets the PlanetResourceStorage's Planet
        /// </summary>
		public override PlanetStorage Planet {
			get { 
				return this.planet;
			}
			set { this.planet = value; }
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				return this.player;
			}
			set { this.player = value; }
		}

		#endregion PlanetResourceStorage Implementation
		
	};
}
