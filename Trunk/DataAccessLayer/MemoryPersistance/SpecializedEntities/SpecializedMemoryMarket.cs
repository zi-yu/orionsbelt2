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
    /// Specialized Memory class for Market
    /// </summary>
	public class SpecializedMemoryMarket : Market {
	
		#region Fields
		
		private System.Collections.Generic.IList<Product> products;
		private SectorStorage sector;

		#endregion Fields
		
		#region Market Implementation
	
		/// <summary>
        /// Gets the Market's Products
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<Product> Products {
			get {
				if( this.products == null ) {
					this.products = new List<Product>();
				}
				return this.products;
			} 
			set {
				this.products = value;
			}
		}

		/// <summary>
        /// Gets the Market's Sector
        /// </summary>
		public override SectorStorage Sector {
			get { 
				return this.sector;
			}
			set { this.sector = value; }
		}

		#endregion Market Implementation
		
	};
}
