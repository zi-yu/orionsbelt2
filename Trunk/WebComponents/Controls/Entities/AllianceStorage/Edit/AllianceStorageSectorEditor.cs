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
    /// Edits the Sector of the AllianceStorage entity
    /// </summary>
	public class AllianceStorageSectorEditor : 
			SectorStorageItem, IEntityFieldEditor<AllianceStorage>, INamingContainer {

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

		#region IEntityFieldEditor<SectorStorage> Implementation
		
		/// <summary>
        /// Updates an AllianceStorage
        /// </summary>
        /// <param name="entity">An instance of AllianceStorage</param>
		public void Update( AllianceStorage entity )
		{
			// OneToMany
			System.Collections.Generic.IList<SectorStorage> list = entity.Sector;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<SectorStorage> Implementation
		
	};

}
