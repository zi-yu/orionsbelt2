
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of GlobalStats from the data source
    /// </summary>
	public class GlobalStatsDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["GlobalStatsDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["GlobalStatsDeleteAll"] == null ) {
					HttpContext.Current.Items["GlobalStatsDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all GlobalStats
        /// </summary>
        void DeleteAll ()
        {
			IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:GlobalStatsDeleteAll()'>Delete All</a>");
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
    function GlobalStatsDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from GlobalStats ?');
			if( !resp ) {
				return;
			}
		
			theForm.GlobalStatsDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"GlobalStatsDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("GlobalStatsDeleteAll", "");
        }

        #endregion

    };

}
