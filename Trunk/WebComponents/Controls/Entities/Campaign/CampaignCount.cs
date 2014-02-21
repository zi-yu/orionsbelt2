
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Campaign in the data source
    /// </summary>
	public class CampaignCount : BaseEntityCount<Campaign> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}