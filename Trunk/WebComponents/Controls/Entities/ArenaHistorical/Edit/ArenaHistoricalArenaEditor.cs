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
    /// Edits the Arena of the ArenaHistorical entity
    /// </summary>
	public class ArenaHistoricalArenaEditor : 
			ArenaStorageItem, IEntityFieldEditor<ArenaHistorical>, INamingContainer {

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

		#region ArenaStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override ArenaStorage GetSourceFromParent( IDescriptable descriptable )
        {
            ArenaHistorical entity = descriptable as ArenaHistorical;
            if (entity == null) {
                return null;
            }
            return entity.Arena;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ArenaHistoricalArena";
		}
		
		#endregion Control unique identifier
		
		#endregion ArenaStorageItem Implementation
		

		#region IEntityFieldEditor<ArenaStorage> Implementation
		
		/// <summary>
        /// Updates an ArenaHistorical
        /// </summary>
        /// <param name="entity">An instance of ArenaHistorical</param>
		public void Update( ArenaHistorical entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Arena = Current;
		}
		
		#endregion IEntityFieldEditor<ArenaStorage> Implementation
		
	};

}
