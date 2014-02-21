
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of SectorStorage in the data source
    /// </summary>
	public class SectorStorageCount : BaseEntityCount<SectorStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SectorStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSectorStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}