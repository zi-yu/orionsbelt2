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
    /// Edits the PlayerStats of the BattleStats entity
    /// </summary>
	public class BattleStatsPlayerStatsEditor : 
			PlayerStatsItem, IEntityFieldEditor<BattleStats>, INamingContainer {

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

		#region PlayerStatsItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PlayerStats GetSourceFromParent( IDescriptable descriptable )
        {
            BattleStats entity = descriptable as BattleStats;
            if (entity == null) {
                return null;
            }
            return entity.PlayerStats;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BattleStatsPlayerStats";
		}
		
		#endregion Control unique identifier
		
		#endregion PlayerStatsItem Implementation
		

		#region IEntityFieldEditor<PlayerStats> Implementation
		
		/// <summary>
        /// Updates an BattleStats
        /// </summary>
        /// <param name="entity">An instance of BattleStats</param>
		public void Update( BattleStats entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.PlayerStats = Current;
		}
		
		#endregion IEntityFieldEditor<PlayerStats> Implementation
		
	};

}
