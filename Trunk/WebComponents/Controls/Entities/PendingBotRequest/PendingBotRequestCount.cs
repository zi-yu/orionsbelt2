
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PendingBotRequest in the data source
    /// </summary>
	public class PendingBotRequestCount : BaseEntityCount<PendingBotRequest> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PendingBotRequestCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPendingBotRequestPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}