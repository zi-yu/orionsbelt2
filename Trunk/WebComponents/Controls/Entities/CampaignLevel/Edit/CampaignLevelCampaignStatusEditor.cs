using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the CampaignStatus of the CampaignLevel entity
    /// </summary>
	public class CampaignLevelCampaignStatusEditor : 
			CampaignStatusItem, IEntityFieldEditor<CampaignLevel>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region IEntityFieldEditor<CampaignStatus> Implementation
		
		/// <summary>
        /// Updates an CampaignLevel
        /// </summary>
        /// <param name="entity">An instance of CampaignLevel</param>
		public void Update( CampaignLevel entity )
		{
			// OneToMany
			System.Collections.Generic.IList<CampaignStatus> list = entity.CampaignStatus;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<CampaignStatus> Implementation
		
	};

}
