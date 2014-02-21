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
    /// Edits the UpdatedDate of the MediaArticle entity
    /// </summary>
	public class MediaArticleUpdatedDateEditor : 
				DateTimeEditor<MediaArticle>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The MediaArticle instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( MediaArticle entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an MediaArticle
        /// </summary>
        /// <param name="entity">An instance of MediaArticle</param>
		public override void Update( MediaArticle entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
