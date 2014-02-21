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
    /// Edits the Fleet of the ArenaStorage entity
    /// </summary>
	public class ArenaStorageFleetEditor : 
			FleetItem, IEntityFieldEditor<ArenaStorage>, INamingContainer {

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

		#region FleetItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Fleet GetSourceFromParent( IDescriptable descriptable )
        {
            ArenaStorage entity = descriptable as ArenaStorage;
            if (entity == null) {
                return null;
            }
            return entity.Fleet;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ArenaStorageFleet";
		}
		
		#endregion Control unique identifier
		
		#endregion FleetItem Implementation
		

		#region IEntityFieldEditor<Fleet> Implementation
		
		/// <summary>
        /// Updates an ArenaStorage
        /// </summary>
        /// <param name="entity">An instance of ArenaStorage</param>
		public void Update( ArenaStorage entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Fleet = Current;
		}
		
		#endregion IEntityFieldEditor<Fleet> Implementation
		
	};

}
