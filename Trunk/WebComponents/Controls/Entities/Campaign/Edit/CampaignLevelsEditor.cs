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
    /// Edits the Levels of the Campaign entity
    /// </summary>
	public class CampaignLevelsEditor : 
			CampaignLevelItem, IEntityFieldEditor<Campaign>, INamingContainer {

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

		#region IEntityFieldEditor<CampaignLevel> Implementation
		
		/// <summary>
        /// Updates an Campaign
        /// </summary>
        /// <param name="entity">An instance of Campaign</param>
		public void Update( Campaign entity )
		{
			// OneToMany
			System.Collections.Generic.IList<CampaignLevel> list = entity.Levels;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<CampaignLevel> Implementation
		
	};

}
