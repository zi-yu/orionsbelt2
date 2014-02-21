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
    /// Edits the LastPost of the ForumTopic entity
    /// </summary>
	public class ForumTopicLastPostEditor : 
				DateTimeEditor<ForumTopic>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The ForumTopic instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( ForumTopic entity )
		{
			return entity.LastPost;
		}
		
		/// <summary>
        /// Updates an ForumTopic
        /// </summary>
        /// <param name="entity">An instance of ForumTopic</param>
		public override void Update( ForumTopic entity )
		{
			entity.LastPost = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
