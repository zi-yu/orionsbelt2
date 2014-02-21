
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of CampaignStatus in the data source
    /// </summary>
	public class CampaignStatusCount : BaseEntityCount<CampaignStatus> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignStatusCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignStatusPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}