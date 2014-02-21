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
    /// Edits the Stats of the PlayerStorage entity
    /// </summary>
	public class PlayerStorageStatsEditor : 
			PlayerStatsItem, IEntityFieldEditor<PlayerStorage>, INamingContainer {

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

		#region PlayerStatsItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PlayerStats GetSourceFromParent( IDescriptable descriptable )
        {
            PlayerStorage entity = descriptable as PlayerStorage;
            if (entity == null) {
                return null;
            }
            return entity.Stats;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "PlayerStorageStats";
		}
		
		#endregion Control unique identifier
		
		#endregion PlayerStatsItem Implementation
		

		#region IEntityFieldEditor<PlayerStats> Implementation
		
		/// <summary>
        /// Updates an PlayerStorage
        /// </summary>
        /// <param name="entity">An instance of PlayerStorage</param>
		public void Update( PlayerStorage entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Stats = Current;
		}
		
		#endregion IEntityFieldEditor<PlayerStats> Implementation
		
	};

}
