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
    /// Specialized Memory class for FriendOrFoe
    /// </summary>
	public class SpecializedMemoryFriendOrFoe : FriendOrFoe {
	
		#region Fields
		
		private PlayerStorage source;
		private PlayerStorage target;

		#endregion Fields
		
		#region FriendOrFoe Implementation
	
		/// <summary>
        /// Gets the FriendOrFoe's Source
        /// </summary>
		public override PlayerStorage Source {
			get { 
				return this.source;
			}
			set { this.source = value; }
		}

		/// <summary>
        /// Gets the FriendOrFoe's Target
        /// </summary>
		public override PlayerStorage Target {
			get { 
				return this.target;
			}
			set { this.target = value; }
		}

		#endregion FriendOrFoe Implementation
		
	};
}
