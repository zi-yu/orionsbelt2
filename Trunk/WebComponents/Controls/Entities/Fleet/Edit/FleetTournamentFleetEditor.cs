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
    /// Edits the TournamentFleet of the Fleet entity
    /// </summary>
	public class FleetTournamentFleetEditor : 
				BoolEditor<Fleet>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			AddValidators();
		}
		
		/// <summary>
        /// Indicates if the boolean is true or false
        /// </summary>
        /// <param name="entity">The Fleet instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Fleet entity )
		{
			return entity.TournamentFleet;
		}
		
		/// <summary>
        /// Updates an Fleet
        /// </summary>
        /// <param name="entity">An instance of Fleet</param>
		public override void Update( Fleet entity )
		{
			entity.TournamentFleet = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "tournamentFleet"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
