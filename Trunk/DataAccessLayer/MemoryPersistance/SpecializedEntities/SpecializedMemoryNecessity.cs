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
    /// Specialized Memory class for Necessity
    /// </summary>
	public class SpecializedMemoryNecessity : Necessity {
	
		#region Fields
		
		private System.Collections.Generic.IList<Task> tasks;
		private PlayerStorage creator;
		private AllianceStorage alliance;

		#endregion Fields
		
		#region Necessity Implementation
	
		/// <summary>
        /// Gets the Necessity's Tasks
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Task> Tasks {
			get {
				if( this.tasks == null ) {
					this.tasks = new List<Task>();
				}
				return this.tasks;
			} 
			set {
				this.tasks = value;
			}
		}

		/// <summary>
        /// Gets the Necessity's Creator
        /// </summary>
		public override PlayerStorage Creator {
			get { 
				return this.creator;
			}
			set { this.creator = value; }
		}

		/// <summary>
        /// Gets the Necessity's Alliance
        /// </summary>
		public override AllianceStorage Alliance {
			get { 
				return this.alliance;
			}
			set { this.alliance = value; }
		}

		#endregion Necessity Implementation
		
	};
}
