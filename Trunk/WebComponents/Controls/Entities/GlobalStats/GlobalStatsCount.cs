
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of GlobalStats in the data source
    /// </summary>
	public class GlobalStatsCount : BaseEntityCount<GlobalStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public GlobalStatsCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetGlobalStatsPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}