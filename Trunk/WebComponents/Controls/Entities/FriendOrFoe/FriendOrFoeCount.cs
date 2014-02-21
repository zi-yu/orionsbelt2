
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of FriendOrFoe in the data source
    /// </summary>
	public class FriendOrFoeCount : BaseEntityCount<FriendOrFoe> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FriendOrFoeCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFriendOrFoePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}