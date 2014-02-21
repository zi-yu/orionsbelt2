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
    /// Edits the CreatedDate of the Product entity
    /// </summary>
	public class ProductCreatedDateEditor : 
				DateTimeEditor<Product>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Product instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Product entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an Product
        /// </summary>
        /// <param name="entity">An instance of Product</param>
		public override void Update( Product entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
