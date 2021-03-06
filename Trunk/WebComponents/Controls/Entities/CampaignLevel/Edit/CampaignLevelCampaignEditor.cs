﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Campaign of the CampaignLevel entity
    /// </summary>
	public class CampaignLevelCampaignEditor : 
			CampaignItem, IEntityFieldEditor<CampaignLevel>, INamingContainer {

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

		#region CampaignItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Campaign GetSourceFromParent( IDescriptable descriptable )
        {
            CampaignLevel entity = descriptable as CampaignLevel;
            if (entity == null) {
                return null;
            }
            return entity.Campaign;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "CampaignLevelCampaign";
		}
		
		#endregion Control unique identifier
		
		#endregion CampaignItem Implementation
		

		#region IEntityFieldEditor<Campaign> Implementation
		
		/// <summary>
        /// Updates an CampaignLevel
        /// </summary>
        /// <param name="entity">An instance of CampaignLevel</param>
		public void Update( CampaignLevel entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Campaign = Current;
		}
		
		#endregion IEntityFieldEditor<Campaign> Implementation
		
	};

}
