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
    /// Edits the Alliance of the Asset entity
    /// </summary>
	public class AssetAllianceEditor : 
			AllianceStorageItem, IEntityFieldEditor<Asset>, INamingContainer {

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

		#region AllianceStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override AllianceStorage GetSourceFromParent( IDescriptable descriptable )
        {
            Asset entity = descriptable as Asset;
            if (entity == null) {
                return null;
            }
            return entity.Alliance;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "AssetAlliance";
		}
		
		#endregion Control unique identifier
		
		#endregion AllianceStorageItem Implementation
		

		#region IEntityFieldEditor<AllianceStorage> Implementation
		
		/// <summary>
        /// Updates an Asset
        /// </summary>
        /// <param name="entity">An instance of Asset</param>
		public void Update( Asset entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Alliance = Current;
		}
		
		#endregion IEntityFieldEditor<AllianceStorage> Implementation
		
	};

}
