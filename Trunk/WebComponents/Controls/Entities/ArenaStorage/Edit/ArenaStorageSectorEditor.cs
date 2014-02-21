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
    /// Edits the Sector of the ArenaStorage entity
    /// </summary>
	public class ArenaStorageSectorEditor : 
			SectorStorageItem, IEntityFieldEditor<ArenaStorage>, INamingContainer {

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

		#region SectorStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override SectorStorage GetSourceFromParent( IDescriptable descriptable )
        {
            ArenaStorage entity = descriptable as ArenaStorage;
            if (entity == null) {
                return null;
            }
            return entity.Sector;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ArenaStorageSector";
		}
		
		#endregion Control unique identifier
		
		#endregion SectorStorageItem Implementation
		

		#region IEntityFieldEditor<SectorStorage> Implementation
		
		/// <summary>
        /// Updates an ArenaStorage
        /// </summary>
        /// <param name="entity">An instance of ArenaStorage</param>
		public void Update( ArenaStorage entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Sector = Current;
		}
		
		#endregion IEntityFieldEditor<SectorStorage> Implementation
		
	};

}
