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
    /// Edits the UpdatedDate of the PlanetResourceStorage entity
    /// </summary>
	public class PlanetResourceStorageUpdatedDateEditor : 
				DateTimeEditor<PlanetResourceStorage>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The PlanetResourceStorage instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( PlanetResourceStorage entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an PlanetResourceStorage
        /// </summary>
        /// <param name="entity">An instance of PlanetResourceStorage</param>
		public override void Update( PlanetResourceStorage entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
