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
    /// Specialized Memory class for Medal
    /// </summary>
	public class SpecializedMemoryMedal : Medal {
	
		#region Fields
		
		private PlayerStorage player;
		private Principal principal;

		#endregion Fields
		
		#region Medal Implementation
	
		/// <summary>
        /// Gets the Medal's Player
        /// </summary>
		public override PlayerStorage Player {
			get { 
				return this.player;
			}
			set { this.player = value; }
		}

		/// <summary>
        /// Gets the Medal's Principal
        /// </summary>
		public override Principal Principal {
			get { 
				return this.principal;
			}
			set { this.principal = value; }
		}

		#endregion Medal Implementation
		
	};
}
