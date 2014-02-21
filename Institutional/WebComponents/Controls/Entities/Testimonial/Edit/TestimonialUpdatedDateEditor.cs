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
    /// Edits the UpdatedDate of the Testimonial entity
    /// </summary>
	public class TestimonialUpdatedDateEditor : 
				DateTimeEditor<Testimonial>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Testimonial instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Testimonial entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an Testimonial
        /// </summary>
        /// <param name="entity">An instance of Testimonial</param>
		public override void Update( Testimonial entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
