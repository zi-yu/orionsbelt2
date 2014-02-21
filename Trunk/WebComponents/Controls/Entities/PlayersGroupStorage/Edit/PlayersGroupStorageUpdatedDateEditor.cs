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
    /// Edits the UpdatedDate of the PlayersGroupStorage entity
    /// </summary>
	public class PlayersGroupStorageUpdatedDateEditor : 
				DateTimeEditor<PlayersGroupStorage>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Gets the Date to be rendered
        /// </summary>
        /// <param name="entity">The PlayersGroupStorage instance</param>
        /// <returns>The DateTime value</returns>
		protected override DateTime GetDateTime( PlayersGroupStorage entity )
		{
			return entity.UpdatedDate;
		}
		
		/// <summary>
        /// Updates an PlayersGroupStorage
        /// </summary>
        /// <param name="entity">An instance of PlayersGroupStorage</param>
		public override void Update( PlayersGroupStorage entity )
		{
			entity.UpdatedDate = new DateTime (Convert.ToInt32(year.SelectedValue),
														Convert.ToInt32(month.SelectedIndex + 1),
														Convert.ToInt32(day.SelectedValue));
		}
		
		#endregion


	};

}
