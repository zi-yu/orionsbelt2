
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of VoteStorage in the data source
    /// </summary>
	public class VoteStorageCount : BaseEntityCount<VoteStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public VoteStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetVoteStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}