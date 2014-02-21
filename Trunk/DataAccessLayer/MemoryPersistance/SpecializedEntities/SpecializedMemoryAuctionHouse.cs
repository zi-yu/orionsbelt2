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
    /// Specialized Memory class for AuctionHouse
    /// </summary>
	public class SpecializedMemoryAuctionHouse : AuctionHouse {
	
		#region Fields
		
		private System.Collections.Generic.IList<BidHistorical> bids;
		private PlayerStorage owner;

		#endregion Fields
		
		#region AuctionHouse Implementation
	
		/// <summary>
        /// Gets the AuctionHouse's Bids
        /// </summary>
		[XmlIgnore()]
		public override System.Collections.Generic.IList<BidHistorical> Bids {
			get {
				if( this.bids == null ) {
					this.bids = new List<BidHistorical>();
				}
				return this.bids;
			} 
			set {
				this.bids = value;
			}
		}

		/// <summary>
        /// Gets the AuctionHouse's Owner
        /// </summary>
		public override PlayerStorage Owner {
			get { 
				return this.owner;
			}
			set { this.owner = value; }
		}

		#endregion AuctionHouse Implementation
		
	};
}
