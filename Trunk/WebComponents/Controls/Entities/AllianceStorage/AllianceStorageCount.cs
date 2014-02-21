
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of AllianceStorage in the data source
    /// </summary>
	public class AllianceStorageCount : BaseEntityCount<AllianceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AllianceStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAllianceStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}