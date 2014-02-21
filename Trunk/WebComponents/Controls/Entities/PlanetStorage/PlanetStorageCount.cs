
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PlanetStorage in the data source
    /// </summary>
	public class PlanetStorageCount : BaseEntityCount<PlanetStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}