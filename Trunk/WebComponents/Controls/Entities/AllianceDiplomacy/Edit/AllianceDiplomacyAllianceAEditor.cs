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
    /// Edits the AllianceA of the AllianceDiplomacy entity
    /// </summary>
	public class AllianceDiplomacyAllianceAEditor : 
			AllianceStorageItem, IEntityFieldEditor<AllianceDiplomacy>, INamingContainer {

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
            AllianceDiplomacy entity = descriptable as AllianceDiplomacy;
            if (entity == null) {
                return null;
            }
            return entity.AllianceA;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "AllianceDiplomacyAllianceA";
		}
		
		#endregion Control unique identifier
		
		#endregion AllianceStorageItem Implementation
		

		#region IEntityFieldEditor<AllianceStorage> Implementation
		
		/// <summary>
        /// Updates an AllianceDiplomacy
        /// </summary>
        /// <param name="entity">An instance of AllianceDiplomacy</param>
		public void Update( AllianceDiplomacy entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.AllianceA = Current;
		}
		
		#endregion IEntityFieldEditor<AllianceStorage> Implementation
		
	};

}
