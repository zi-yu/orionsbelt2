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
    /// Edits the MinLadder of the PrincipalStats entity
    /// </summary>
	public class PrincipalStatsMinLadderEditor : 
				IntEditor<PrincipalStats>, INamingContainer {
		
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
        /// <param name="entity">The PrincipalStats</param>
        /// <returns>The value</returns>
		protected override int GetNumber( PrincipalStats entity )
		{
			return entity.MinLadder;
		}


		/// <summary>
        /// Updates an PrincipalStats
        /// </summary>
        /// <param name="entity">An instance of PrincipalStats</param>
		public override void Update( PrincipalStats entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.MinLadder = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_minLadder", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
