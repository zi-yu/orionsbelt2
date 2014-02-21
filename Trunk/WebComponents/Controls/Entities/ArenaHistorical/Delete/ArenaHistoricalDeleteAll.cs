
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of ArenaHistorical from the data source
    /// </summary>
	public class ArenaHistoricalDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["ArenaHistoricalDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["ArenaHistoricalDeleteAll"] == null ) {
					HttpContext.Current.Items["ArenaHistoricalDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all ArenaHistorical
        /// </summary>
        void DeleteAll ()
        {
			IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:ArenaHistoricalDeleteAll()'>Delete All</a>");
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
    function ArenaHistoricalDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from ArenaHistorical ?');
			if( !resp ) {
				return;
			}
		
			theForm.ArenaHistoricalDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"ArenaHistoricalDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("ArenaHistoricalDeleteAll", "");
        }

        #endregion

    };

}
