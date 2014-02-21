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
    /// Edits the LastWarningDate of the Principal entity
    /// </summary>
	public class PrincipalLastWarningDateEditor : 
				DateTimeEditor<Principal>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Principal instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Principal entity )
		{
			return entity.LastWarningDate;
		}
		
		/// <summary>
        /// Updates an Principal
        /// </summary>
        /// <param name="entity">An instance of Principal</param>
		public override void Update( Principal entity )
		{
			entity.LastWarningDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
