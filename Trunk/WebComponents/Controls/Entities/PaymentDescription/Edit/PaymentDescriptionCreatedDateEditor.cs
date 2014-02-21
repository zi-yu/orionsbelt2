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
    /// Edits the CreatedDate of the PaymentDescription entity
    /// </summary>
	public class PaymentDescriptionCreatedDateEditor : 
				DateTimeEditor<PaymentDescription>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The PaymentDescription instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( PaymentDescription entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an PaymentDescription
        /// </summary>
        /// <param name="entity">An instance of PaymentDescription</param>
		public override void Update( PaymentDescription entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
