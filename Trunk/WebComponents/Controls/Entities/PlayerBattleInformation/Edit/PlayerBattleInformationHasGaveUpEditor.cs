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
    /// Edits the HasGaveUp of the PlayerBattleInformation entity
    /// </summary>
	public class PlayerBattleInformationHasGaveUpEditor : 
				BoolEditor<PlayerBattleInformation>, INamingContainer {
		
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
        /// <param name="entity">The PlayerBattleInformation instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( PlayerBattleInformation entity )
		{
			return entity.HasGaveUp;
		}
		
		/// <summary>
        /// Updates an PlayerBattleInformation
        /// </summary>
        /// <param name="entity">An instance of PlayerBattleInformation</param>
		public override void Update( PlayerBattleInformation entity )
		{
			entity.HasGaveUp = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "hasGaveUp"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
