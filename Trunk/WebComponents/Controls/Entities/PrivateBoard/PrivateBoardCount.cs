
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PrivateBoard in the data source
    /// </summary>
	public class PrivateBoardCount : BaseEntityCount<PrivateBoard> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrivateBoardCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrivateBoardPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}