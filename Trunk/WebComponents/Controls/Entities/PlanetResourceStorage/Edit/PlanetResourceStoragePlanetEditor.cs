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
    /// Edits the Planet of the PlanetResourceStorage entity
    /// </summary>
	public class PlanetResourceStoragePlanetEditor : 
			PlanetStorageItem, IEntityFieldEditor<PlanetResourceStorage>, INamingContainer {

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
            PlanetResourceStorage entity = descriptable as PlanetResourceStorage;
            if (entity == null) {
                return null;
            }
            return entity.Planet;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "PlanetResourceStoragePlanet";
		}
		
		#endregion Control unique identifier
		
		#endregion PlanetStorageItem Implementation
		

		#region IEntityFieldEditor<PlanetStorage> Implementation
		
		/// <summary>
        /// Updates an PlanetResourceStorage
        /// </summary>
        /// <param name="entity">An instance of PlanetResourceStorage</param>
		public void Update( PlanetResourceStorage entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Planet = Current;
		}
		
		#endregion IEntityFieldEditor<PlanetStorage> Implementation
		
	};

}
