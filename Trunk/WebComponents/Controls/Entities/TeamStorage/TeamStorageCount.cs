
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of TeamStorage in the data source
    /// </summary>
	public class TeamStorageCount : BaseEntityCount<TeamStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TeamStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTeamStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}