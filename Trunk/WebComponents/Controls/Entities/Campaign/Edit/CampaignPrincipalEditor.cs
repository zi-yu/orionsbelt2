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
    /// Edits the Principal of the Campaign entity
    /// </summary>
	public class CampaignPrincipalEditor : 
			PrincipalItem, IEntityFieldEditor<Campaign>, INamingContainer {

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

		#region PrincipalItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Principal GetSourceFromParent( IDescriptable descriptable )
        {
            Campaign entity = descriptable as Campaign;
            if (entity == null) {
                return null;
            }
            return entity.Principal;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "CampaignPrincipal";
		}
		
		#endregion Control unique identifier
		
		#endregion PrincipalItem Implementation
		

		#region IEntityFieldEditor<Principal> Implementation
		
		/// <summary>
        /// Updates an Campaign
        /// </summary>
        /// <param name="entity">An instance of Campaign</param>
		public void Update( Campaign entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Principal = Current;
		}
		
		#endregion IEntityFieldEditor<Principal> Implementation
		
	};

}
