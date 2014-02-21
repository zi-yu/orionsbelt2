
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of GroupPointsStorage in the data source
    /// </summary>
	public class GroupPointsStorageCount : BaseEntityCount<GroupPointsStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public GroupPointsStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetGroupPointsStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}