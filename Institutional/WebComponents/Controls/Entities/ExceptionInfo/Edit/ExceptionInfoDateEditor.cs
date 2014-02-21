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
    /// Edits the Date of the ExceptionInfo entity
    /// </summary>
	public class ExceptionInfoDateEditor : 
				DateTimeEditor<ExceptionInfo>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The ExceptionInfo instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( ExceptionInfo entity )
		{
			return entity.Date;
		}
		
		/// <summary>
        /// Updates an ExceptionInfo
        /// </summary>
        /// <param name="entity">An instance of ExceptionInfo</param>
		public override void Update( ExceptionInfo entity )
		{
			entity.Date = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
