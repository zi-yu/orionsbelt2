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
    /// Specialized Memory class for Product
    /// </summary>
	public class SpecializedMemoryProduct : Product {
	
		#region Fields
		
		private Market market;

		#endregion Fields
		
		#region Product Implementation
	
		/// <summary>
        /// Gets the Product's Market
        /// </summary>
		public override Market Market {
			get { 
				return this.market;
			}
			set { this.market = value; }
		}

		#endregion Product Implementation
		
	};
}
