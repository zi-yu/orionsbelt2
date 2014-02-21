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
    /// Edits the UpdatedDate of the Referral entity
    /// </summary>
	public class ReferralUpdatedDateEditor : 
				DateTimeEditor<Referral>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Referral instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Referral entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an Referral
        /// </summary>
        /// <param name="entity">An instance of Referral</param>
		public override void Update( Referral entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
