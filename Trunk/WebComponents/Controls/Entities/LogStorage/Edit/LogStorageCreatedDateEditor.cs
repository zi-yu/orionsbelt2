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
    /// Edits the CreatedDate of the LogStorage entity
    /// </summary>
	public class LogStorageCreatedDateEditor : 
				DateTimeEditor<LogStorage>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The LogStorage instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( LogStorage entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an LogStorage
        /// </summary>
        /// <param name="entity">An instance of LogStorage</param>
		public override void Update( LogStorage entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
