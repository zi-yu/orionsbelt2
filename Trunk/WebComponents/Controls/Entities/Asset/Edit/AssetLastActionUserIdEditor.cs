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
    /// Edits the LastActionUserId of the Asset entity
    /// </summary>
	public class AssetLastActionUserIdEditor : 
				IntEditor<Asset>, INamingContainer {
		
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
        /// <param name="entity">The Asset</param>
        /// <returns>The value</returns>
		protected override int GetNumber( Asset entity )
		{
			return entity.LastActionUserId;
		}


		/// <summary>
        /// Updates an Asset
        /// </summary>
        /// <param name="entity">An instance of Asset</param>
		public override void Update( Asset entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.LastActionUserId = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_lastActionUserId", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
