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
    /// Edits the CreatedDate of the ArenaHistorical entity
    /// </summary>
	public class ArenaHistoricalCreatedDateEditor : 
				DateTimeEditor<ArenaHistorical>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The ArenaHistorical instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( ArenaHistorical entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an ArenaHistorical
        /// </summary>
        /// <param name="entity">An instance of ArenaHistorical</param>
		public override void Update( ArenaHistorical entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
