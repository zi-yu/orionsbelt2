
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of TeamStorage from the data source
    /// </summary>
	public class TeamStorageDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["TeamStorageDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["TeamStorageDeleteAll"] == null ) {
					HttpContext.Current.Items["TeamStorageDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all TeamStorage
        /// </summary>
        void DeleteAll ()
        {
			ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:TeamStorageDeleteAll()'>Delete All</a>");
		}
		
		#endregion Control Implementation

        #region Delete JS

		/// <summary>
        /// Registers necessary JavaScript
        /// </summary>
        private void RegisterDeleteJS()
        {
            string script = @"<script type='text/javascript'>
	var theForm = document.forms['" + Page.Form.ClientID + @"'];
    if (!theForm) {
        theForm = document.form;
    }
    function TeamStorageDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from TeamStorage ?');
			if( !resp ) {
				return;
			}
		
			theForm.TeamStorageDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"TeamStorageDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("TeamStorageDeleteAll", "");
        }

        #endregion

    };

}
