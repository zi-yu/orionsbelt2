
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ArenaHistorical in the data source
    /// </summary>
	public class ArenaHistoricalCount : BaseEntityCount<ArenaHistorical> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaHistoricalCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaHistoricalPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}