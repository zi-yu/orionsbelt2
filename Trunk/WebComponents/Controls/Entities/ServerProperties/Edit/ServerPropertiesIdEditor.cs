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
    /// Edits the Id of the ServerProperties entity
    /// </summary>
	public class ServerPropertiesIdEditor : 
				IntEditor<ServerProperties>, INamingContainer {
		
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
        /// Gets the value of the property do edit
        /// </summary>
        /// <param name="entity">The ServerProperties</param>
        /// <returns>The value</returns>
		protected override int GetNumber( ServerProperties entity )
		{
			return entity.Id;
		}

		/// <summary>
        /// Renders an ServerProperties
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The ServerProperties instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, ServerProperties entity, int renderCount, bool flipFlop )
		{
			// let's not edit primary keys...
			writer.Write(GetNumber(entity));
		}

		/// <summary>
        /// Updates an ServerProperties
        /// </summary>
        /// <param name="entity">An instance of ServerProperties</param>
		public override void Update( ServerProperties entity )
		{
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_id", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
