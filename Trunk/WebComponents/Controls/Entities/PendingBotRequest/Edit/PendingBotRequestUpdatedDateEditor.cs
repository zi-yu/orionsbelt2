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
    /// Edits the UpdatedDate of the PendingBotRequest entity
    /// </summary>
	public class PendingBotRequestUpdatedDateEditor : 
				DateTimeEditor<PendingBotRequest>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The PendingBotRequest instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( PendingBotRequest entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an PendingBotRequest
        /// </summary>
        /// <param name="entity">An instance of PendingBotRequest</param>
		public override void Update( PendingBotRequest entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
