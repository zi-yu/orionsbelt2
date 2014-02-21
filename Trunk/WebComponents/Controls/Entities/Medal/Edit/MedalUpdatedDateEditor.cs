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
    /// Edits the UpdatedDate of the Medal entity
    /// </summary>
	public class MedalUpdatedDateEditor : 
				DateTimeEditor<Medal>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Medal instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Medal entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an Medal
        /// </summary>
        /// <param name="entity">An instance of Medal</param>
		public override void Update( Medal entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
