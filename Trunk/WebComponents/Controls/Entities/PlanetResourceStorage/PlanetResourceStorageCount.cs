
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlanetResourceStorage in the data source
    /// </summary>
	public class PlanetResourceStorageCount : BaseEntityCount<PlanetResourceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetResourceStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetResourceStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}