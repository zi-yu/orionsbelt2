
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of AuctionHouse in the data source
    /// </summary>
	public class AuctionHouseCount : BaseEntityCount<AuctionHouse> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AuctionHouseCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAuctionHousePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}