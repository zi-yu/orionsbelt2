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
    /// Edits the EndTick of the PlanetResourceStorage entity
    /// </summary>
	public class PlanetResourceStorageEndTickEditor : 
				IntEditor<PlanetResourceStorage>, INamingContainer {
		
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
        /// <param name="entity">The PlanetResourceStorage</param>
        /// <returns>The value</returns>
		protected override int GetNumber( PlanetResourceStorage entity )
		{
			return entity.EndTick;
		}


		/// <summary>
        /// Updates an PlanetResourceStorage
        /// </summary>
        /// <param name="entity">An instance of PlanetResourceStorage</param>
		public override void Update( PlanetResourceStorage entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.EndTick = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_endTick", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
