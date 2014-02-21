
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of ArenaStorage from the data source
    /// </summary>
	public class ArenaStorageDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["ArenaStorageDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["ArenaStorageDeleteAll"] == null ) {
					HttpContext.Current.Items["ArenaStorageDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all ArenaStorage
        /// </summary>
        void DeleteAll ()
        {
			IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:ArenaStorageDeleteAll()'>Delete All</a>");
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
    function ArenaStorageDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from ArenaStorage ?');
			if( !resp ) {
				return;
			}
		
			theForm.ArenaStorageDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"ArenaStorageDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("ArenaStorageDeleteAll", "");
        }

        #endregion

    };

}
