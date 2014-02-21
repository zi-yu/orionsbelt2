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
    /// Edits the Player of the PlayerStats entity
    /// </summary>
	public class PlayerStatsPlayerEditor : 
			PlayerStorageItem, IEntityFieldEditor<PlayerStats>, INamingContainer {

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

		#region IEntityFieldEditor<PlayerStorage> Implementation
		
		/// <summary>
        /// Updates an PlayerStats
        /// </summary>
        /// <param name="entity">An instance of PlayerStats</param>
		public void Update( PlayerStats entity )
		{
			// OneToMany
			System.Collections.Generic.IList<PlayerStorage> list = entity.Player;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<PlayerStorage> Implementation
		
	};

}
