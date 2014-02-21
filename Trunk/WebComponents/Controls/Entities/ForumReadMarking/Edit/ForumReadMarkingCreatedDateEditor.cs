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
    /// Edits the CreatedDate of the ForumReadMarking entity
    /// </summary>
	public class ForumReadMarkingCreatedDateEditor : 
				DateTimeEditor<ForumReadMarking>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The ForumReadMarking instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( ForumReadMarking entity )
		{
			return entity.CreatedDate;
		}
		
		/// <summary>
        /// Updates an ForumReadMarking
        /// </summary>
        /// <param name="entity">An instance of ForumReadMarking</param>
		public override void Update( ForumReadMarking entity )
		{
			entity.CreatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
