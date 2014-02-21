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
    /// Edits the Battles of the PlayersGroupStorage entity
    /// </summary>
	public class PlayersGroupStorageBattlesEditor : 
			BattleItem, IEntityFieldEditor<PlayersGroupStorage>, INamingContainer {

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

		#region IEntityFieldEditor<Battle> Implementation
		
		/// <summary>
        /// Updates an PlayersGroupStorage
        /// </summary>
        /// <param name="entity">An instance of PlayersGroupStorage</param>
		public void Update( PlayersGroupStorage entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Battle> list = entity.Battles;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Battle> Implementation
		
	};

}
