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
    /// Specialized Memory class for Task
    /// </summary>
	public class SpecializedMemoryTask : Task {
	
		#region Fields
		
		private System.Collections.Generic.IList<Asset> assets;
		private Necessity necessity;

		#endregion Fields
		
		#region Task Implementation
	
		/// <summary>
        /// Gets the Task's Assets
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Asset> Assets {
			get {
				if( this.assets == null ) {
					this.assets = new List<Asset>();
				}
				return this.assets;
			} 
			set {
				this.assets = value;
			}
		}

		/// <summary>
        /// Gets the Task's Necessity
        /// </summary>
		public override Necessity Necessity {
			get { 
				return this.necessity;
			}
			set { this.necessity = value; }
		}

		#endregion Task Implementation
		
	};
}
