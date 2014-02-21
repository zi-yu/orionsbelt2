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
    /// Edits the BeginDate of the Promotion entity
    /// </summary>
	public class PromotionBeginDateEditor : 
				DateTimeEditor<Promotion>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The Promotion instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( Promotion entity )
		{
			return entity.BeginDate;
		}
		
		/// <summary>
        /// Updates an Promotion
        /// </summary>
        /// <param name="entity">An instance of Promotion</param>
		public override void Update( Promotion entity )
		{
			entity.BeginDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
