﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Tournament of the Battle entity
    /// </summary>
	public class BattleTournamentEditor : 
			TournamentItem, IEntityFieldEditor<Battle>, INamingContainer {

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

		#region TournamentItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Tournament GetSourceFromParent( IDescriptable descriptable )
        {
            Battle entity = descriptable as Battle;
            if (entity == null) {
                return null;
            }
            return entity.Tournament;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "BattleTournament";
		}
		
		#endregion Control unique identifier
		
		#endregion TournamentItem Implementation
		

		#region IEntityFieldEditor<Tournament> Implementation
		
		/// <summary>
        /// Updates an Battle
        /// </summary>
        /// <param name="entity">An instance of Battle</param>
		public void Update( Battle entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Tournament = Current;
		}
		
		#endregion IEntityFieldEditor<Tournament> Implementation
		
	};

}
