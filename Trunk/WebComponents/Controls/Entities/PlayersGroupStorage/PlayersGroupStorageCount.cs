
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlayersGroupStorage in the data source
    /// </summary>
	public class PlayersGroupStorageCount : BaseEntityCount<PlayersGroupStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayersGroupStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayersGroupStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}