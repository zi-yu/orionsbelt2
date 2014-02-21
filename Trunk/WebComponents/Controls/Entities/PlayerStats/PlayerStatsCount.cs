
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlayerStats in the data source
    /// </summary>
	public class PlayerStatsCount : BaseEntityCount<PlayerStats> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStatsCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStatsPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}