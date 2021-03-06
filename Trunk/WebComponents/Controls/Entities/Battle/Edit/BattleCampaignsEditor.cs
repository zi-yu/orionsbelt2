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
    /// Edits the Campaigns of the Battle entity
    /// </summary>
	public class BattleCampaignsEditor : 
			CampaignStatusItem, IEntityFieldEditor<Battle>, INamingContainer {

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
        /// Updates an Battle
        /// </summary>
        /// <param name="entity">An instance of Battle</param>
		public void Update( Battle entity )
		{
			// OneToMany
			System.Collections.Generic.IList<CampaignStatus> list = entity.Campaigns;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<CampaignStatus> Implementation
		
	};

}
