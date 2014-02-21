using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Edits the CreatedDate of the Server entity
    /// </summary>
	public class ServerCreatedDateEditor : 
				DateTimeEditor<Server>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Server instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Server entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an Server
        /// </summary>
        /// <param name="entity">An instance of Server</param>
		public override void Update( Server entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
