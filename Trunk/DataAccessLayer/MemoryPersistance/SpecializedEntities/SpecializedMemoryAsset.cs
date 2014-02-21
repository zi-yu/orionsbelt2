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
    /// Specialized Memory class for Asset
    /// </summary>
	public class SpecializedMemoryAsset : Asset {
	
		#region Fields
		
		private PlayerStorage owner;
		private Task task;
		private AllianceStorage alliance;

		#endregion Fields
		
		#region Asset Implementation
	
		/// <summary>
        /// Gets the Asset's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		/// <summary>
        /// Gets the Asset's Task
        /// </summary>
		public override Task Task {
			get { 
				return this.task;
			}
			set { this.task = value; }
		}

		/// <summary>
        /// Gets the Asset's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				return this.alliance;
			}
			set { this.alliance = value; }
		}

		#endregion Asset Implementation
		
	};
}
