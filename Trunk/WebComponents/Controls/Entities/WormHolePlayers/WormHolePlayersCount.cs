
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of WormHolePlayers in the data source
    /// </summary>
	public class WormHolePlayersCount : BaseEntityCount<WormHolePlayers> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public WormHolePlayersCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetWormHolePlayersPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}