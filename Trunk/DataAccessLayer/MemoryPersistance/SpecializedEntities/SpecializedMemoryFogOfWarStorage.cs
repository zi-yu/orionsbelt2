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
    /// Specialized Memory class for FogOfWarStorage
    /// </summary>
	public class SpecializedMemoryFogOfWarStorage : FogOfWarStorage {
	
		#region Fields
		
		private PlayerStorage owner;

		#endregion Fields
		
		#region FogOfWarStorage Implementation
	
		/// <summary>
        /// Gets the FogOfWarStorage's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		#endregion FogOfWarStorage Implementation
		
	};
}
