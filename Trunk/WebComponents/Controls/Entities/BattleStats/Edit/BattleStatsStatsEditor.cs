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
    /// Edits the Stats of the BattleStats entity
    /// </summary>
	public class BattleStatsStatsEditor : 
			PrincipalStatsItem, IEntityFieldEditor<BattleStats>, INamingContainer {

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

		#region PrincipalStatsItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PrincipalStats GetSourceFromParent( IDescriptable descriptable )
        {
            BattleStats entity = descriptable as BattleStats;
            if (entity == null) {
                return null;
            }
            return entity.Stats;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BattleStatsStats";
		}
		
		#endregion Control unique identifier
		
		#endregion PrincipalStatsItem Implementation
		

		#region IEntityFieldEditor<PrincipalStats> Implementation
		
		/// <summary>
        /// Updates an BattleStats
        /// </summary>
        /// <param name="entity">An instance of BattleStats</param>
		public void Update( BattleStats entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Stats = Current;
		}
		
		#endregion IEntityFieldEditor<PrincipalStats> Implementation
		
	};

}
