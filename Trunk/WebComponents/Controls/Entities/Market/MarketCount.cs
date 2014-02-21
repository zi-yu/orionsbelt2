
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Market in the data source
    /// </summary>
	public class MarketCount : BaseEntityCount<Market> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MarketCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMarketPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}