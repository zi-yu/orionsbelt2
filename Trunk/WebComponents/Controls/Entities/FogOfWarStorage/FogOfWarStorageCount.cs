
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of FogOfWarStorage in the data source
    /// </summary>
	public class FogOfWarStorageCount : BaseEntityCount<FogOfWarStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FogOfWarStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFogOfWarStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}