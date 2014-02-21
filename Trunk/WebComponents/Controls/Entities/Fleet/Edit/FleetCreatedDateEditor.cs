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
    /// Edits the CreatedDate of the Fleet entity
    /// </summary>
	public class FleetCreatedDateEditor : 
				DateTimeEditor<Fleet>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Fleet instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Fleet entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an Fleet
        /// </summary>
        /// <param name="entity">An instance of Fleet</param>
		public override void Update( Fleet entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
