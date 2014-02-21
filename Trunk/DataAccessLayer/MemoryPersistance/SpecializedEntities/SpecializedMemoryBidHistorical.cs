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
    /// Specialized Memory class for BidHistorical
    /// </summary>
	public class SpecializedMemoryBidHistorical : BidHistorical {
	
		#region Fields
		
		private AuctionHouse resource;
		private PlayerStorage madeBy;

		#endregion Fields
		
		#region BidHistorical Implementation
	
		/// <summary>
        /// Gets the BidHistorical's Resource
        /// </summary>
		public override AuctionHouse Resource {
			get { 
				return this.resource;
			}
			set { this.resource = value; }
		}

		/// <summary>
        /// Gets the BidHistorical's MadeBy
        /// </summary>
		public override PlayerStorage MadeBy {
			get { 
				return this.madeBy;
			}
			set { this.madeBy = value; }
		}

		#endregion BidHistorical Implementation
		
	};
}
