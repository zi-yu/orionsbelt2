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
    /// Edits the Participants of the Campaign entity
    /// </summary>
	public class CampaignParticipantsEditor : 
			CampaignStatusItem, IEntityFieldEditor<Campaign>, INamingContainer {

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
        /// Updates an Campaign
        /// </summary>
        /// <param name="entity">An instance of Campaign</param>
		public void Update( Campaign entity )
		{
			// OneToMany
			System.Collections.Generic.IList<CampaignStatus> list = entity.Participants;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<CampaignStatus> Implementation
		
	};

}
