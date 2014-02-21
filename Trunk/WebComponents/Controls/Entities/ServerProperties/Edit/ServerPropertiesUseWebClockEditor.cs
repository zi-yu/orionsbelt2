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
    /// Edits the UseWebClock of the ServerProperties entity
    /// </summary>
	public class ServerPropertiesUseWebClockEditor : 
				BoolEditor<ServerProperties>, INamingContainer {
		
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
        /// <param name="entity">The ServerProperties instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( ServerProperties entity )
		{
			return entity.UseWebClock;
		}
		
		/// <summary>
        /// Updates an ServerProperties
        /// </summary>
        /// <param name="entity">An instance of ServerProperties</param>
		public override void Update( ServerProperties entity )
		{
			entity.UseWebClock = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "useWebClock"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
