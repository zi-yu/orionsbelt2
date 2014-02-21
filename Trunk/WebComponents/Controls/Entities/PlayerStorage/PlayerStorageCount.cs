
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlayerStorage in the data source
    /// </summary>
	public class PlayerStorageCount : BaseEntityCount<PlayerStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlayerStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlayerStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}