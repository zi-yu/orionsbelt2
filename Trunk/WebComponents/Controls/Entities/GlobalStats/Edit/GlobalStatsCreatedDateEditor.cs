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
    /// Edits the CreatedDate of the GlobalStats entity
    /// </summary>
	public class GlobalStatsCreatedDateEditor : 
				DateTimeEditor<GlobalStats>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The GlobalStats instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( GlobalStats entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an GlobalStats
        /// </summary>
        /// <param name="entity">An instance of GlobalStats</param>
		public override void Update( GlobalStats entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
