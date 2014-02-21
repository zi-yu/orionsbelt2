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
    /// Edits the Fleets of the PlanetStorage entity
    /// </summary>
	public class PlanetStorageFleetsEditor : 
			FleetItem, IEntityFieldEditor<PlanetStorage>, INamingContainer {

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

		#region IEntityFieldEditor<Fleet> Implementation
		
		/// <summary>
        /// Updates an PlanetStorage
        /// </summary>
        /// <param name="entity">An instance of PlanetStorage</param>
		public void Update( PlanetStorage entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Fleet> list = entity.Fleets;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Fleet> Implementation
		
	};

}
