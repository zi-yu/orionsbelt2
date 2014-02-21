using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the CreatedDate of the TeamStorage entity
    /// </summary>
	public class TeamStorageCreatedDateEditor : 
				DateTimeEditor<TeamStorage>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The TeamStorage instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( TeamStorage entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an TeamStorage
        /// </summary>
        /// <param name="entity">An instance of TeamStorage</param>
		public override void Update( TeamStorage entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
