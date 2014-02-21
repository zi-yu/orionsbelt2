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
    /// Edits the Arena of the Fleet entity
    /// </summary>
	public class FleetArenaEditor : 
			ArenaStorageItem, IEntityFieldEditor<Fleet>, INamingContainer {

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

		#region IEntityFieldEditor<ArenaStorage> Implementation
		
		/// <summary>
        /// Updates an Fleet
        /// </summary>
        /// <param name="entity">An instance of Fleet</param>
		public void Update( Fleet entity )
		{
			// OneToMany
			System.Collections.Generic.IList<ArenaStorage> list = entity.Arena;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<ArenaStorage> Implementation
		
	};

}
