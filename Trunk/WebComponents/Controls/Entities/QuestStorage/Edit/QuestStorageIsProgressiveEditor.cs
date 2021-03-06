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
    /// Edits the IsProgressive of the QuestStorage entity
    /// </summary>
	public class QuestStorageIsProgressiveEditor : 
				BoolEditor<QuestStorage>, INamingContainer {
		
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
        /// <param name="entity">The QuestStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( QuestStorage entity )
		{
			return entity.IsProgressive;
		}
		
		/// <summary>
        /// Updates an QuestStorage
        /// </summary>
        /// <param name="entity">An instance of QuestStorage</param>
		public override void Update( QuestStorage entity )
		{
			entity.IsProgressive = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isProgressive"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
