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
    /// Specialized Memory class for Promotion
    /// </summary>
	public class SpecializedMemoryPromotion : Promotion {
	
		#region Fields
		
		private System.Collections.Generic.IList<ActivatedPromotion> activations;
		private Principal owner;

		#endregion Fields
		
		#region Promotion Implementation
	
		/// <summary>
        /// Gets the Promotion's Activations
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<ActivatedPromotion> Activations {
			get {
				if( this.activations == null ) {
					this.activations = new List<ActivatedPromotion>();
				}
				return this.activations;
			} 
			set {
				this.activations = value;
			}
		}

		/// <summary>
        /// Gets the Promotion's Owner
        /// </summary>
		public override Principal Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		#endregion Promotion Implementation
		
	};
}
