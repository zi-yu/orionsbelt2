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
    /// Edits the LevelTemplate of the CampaignStatus entity
    /// </summary>
	public class CampaignStatusLevelTemplateEditor : 
			CampaignLevelItem, IEntityFieldEditor<CampaignStatus>, INamingContainer {

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

		#region CampaignLevelItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override CampaignLevel GetSourceFromParent( IDescriptable descriptable )
        {
            CampaignStatus entity = descriptable as CampaignStatus;
            if (entity == null) {
                return null;
            }
            return entity.LevelTemplate;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "CampaignStatusLevelTemplate";
		}
		
		#endregion Control unique identifier
		
		#endregion CampaignLevelItem Implementation
		

		#region IEntityFieldEditor<CampaignLevel> Implementation
		
		/// <summary>
        /// Updates an CampaignStatus
        /// </summary>
        /// <param name="entity">An instance of CampaignStatus</param>
		public void Update( CampaignStatus entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.LevelTemplate = Current;
		}
		
		#endregion IEntityFieldEditor<CampaignLevel> Implementation
		
	};

}
