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
    /// Edits the CreatedDate of the PrincipalStats entity
    /// </summary>
	public class PrincipalStatsCreatedDateEditor : 
				DateTimeEditor<PrincipalStats>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The PrincipalStats instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( PrincipalStats entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an PrincipalStats
        /// </summary>
        /// <param name="entity">An instance of PrincipalStats</param>
		public override void Update( PrincipalStats entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
