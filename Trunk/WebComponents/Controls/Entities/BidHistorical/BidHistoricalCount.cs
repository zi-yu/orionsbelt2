
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of BidHistorical in the data source
    /// </summary>
	public class BidHistoricalCount : BaseEntityCount<BidHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public BidHistoricalCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetBidHistoricalPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}