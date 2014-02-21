
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of DuplicateDetection from the data source
    /// </summary>
	public class DuplicateDetectionDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["DuplicateDetectionDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["DuplicateDetectionDeleteAll"] == null ) {
					HttpContext.Current.Items["DuplicateDetectionDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all DuplicateDetection
        /// </summary>
        void DeleteAll ()
        {
			IDuplicateDetectionPersistance persistance = Persistance.Instance.GetDuplicateDetectionPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:DuplicateDetectionDeleteAll()'>Delete All</a>");
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
    function DuplicateDetectionDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from DuplicateDetection ?');
			if( !resp ) {
				return;
			}
		
			theForm.DuplicateDetectionDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"DuplicateDetectionDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("DuplicateDetectionDeleteAll", "");
        }

        #endregion

    };

}
