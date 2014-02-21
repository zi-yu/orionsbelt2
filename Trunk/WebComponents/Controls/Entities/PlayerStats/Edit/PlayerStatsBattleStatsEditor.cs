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
    /// Edits the BattleStats of the PlayerStats entity
    /// </summary>
	public class PlayerStatsBattleStatsEditor : 
			BattleStatsItem, IEntityFieldEditor<PlayerStats>, INamingContainer {

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

		#region IEntityFieldEditor<BattleStats> Implementation
		
		/// <summary>
        /// Updates an PlayerStats
        /// </summary>
        /// <param name="entity">An instance of PlayerStats</param>
		public void Update( PlayerStats entity )
		{
			// OneToMany
			System.Collections.Generic.IList<BattleStats> list = entity.BattleStats;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<BattleStats> Implementation
		
	};

}
