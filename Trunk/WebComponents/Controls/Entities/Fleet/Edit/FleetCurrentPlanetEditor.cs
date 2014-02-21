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
    /// Edits the CurrentPlanet of the Fleet entity
    /// </summary>
	public class FleetCurrentPlanetEditor : 
			PlanetStorageItem, IEntityFieldEditor<Fleet>, INamingContainer {

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

		#region PlanetStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PlanetStorage GetSourceFromParent( IDescriptable descriptable )
        {
            Fleet entity = descriptable as Fleet;
            if (entity == null) {
                return null;
            }
            return entity.CurrentPlanet;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "FleetCurrentPlanet";
		}
		
		#endregion Control unique identifier
		
		#endregion PlanetStorageItem Implementation
		

		#region IEntityFieldEditor<PlanetStorage> Implementation
		
		/// <summary>
        /// Updates an Fleet
        /// </summary>
        /// <param name="entity">An instance of Fleet</param>
		public void Update( Fleet entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.CurrentPlanet = Current;
		}
		
		#endregion IEntityFieldEditor<PlanetStorage> Implementation
		
	};

}
