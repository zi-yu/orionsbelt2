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
    /// Edits the UpdatedDate of the Invoice entity
    /// </summary>
	public class InvoiceUpdatedDateEditor : 
				DateTimeEditor<Invoice>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Invoice instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Invoice entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an Invoice
        /// </summary>
        /// <param name="entity">An instance of Invoice</param>
		public override void Update( Invoice entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
