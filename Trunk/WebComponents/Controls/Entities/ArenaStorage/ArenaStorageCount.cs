
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ArenaStorage in the data source
    /// </summary>
	public class ArenaStorageCount : BaseEntityCount<ArenaStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ArenaStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetArenaStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}