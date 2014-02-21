
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of CampaignLevel in the data source
    /// </summary>
	public class CampaignLevelCount : BaseEntityCount<CampaignLevel> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CampaignLevelCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCampaignLevelPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}