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
    /// Edits the CreatedDate of the Necessity entity
    /// </summary>
	public class NecessityCreatedDateEditor : 
				DateTimeEditor<Necessity>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Necessity instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Necessity entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an Necessity
        /// </summary>
        /// <param name="entity">An instance of Necessity</param>
		public override void Update( Necessity entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
