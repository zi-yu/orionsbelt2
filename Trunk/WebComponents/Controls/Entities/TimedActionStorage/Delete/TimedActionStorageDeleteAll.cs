
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of TimedActionStorage from the data source
    /// </summary>
	public class TimedActionStorageDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["TimedActionStorageDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["TimedActionStorageDeleteAll"] == null ) {
					HttpContext.Current.Items["TimedActionStorageDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all TimedActionStorage
        /// </summary>
        void DeleteAll ()
        {
			ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:TimedActionStorageDeleteAll()'>Delete All</a>");
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
    function TimedActionStorageDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from TimedActionStorage ?');
			if( !resp ) {
				return;
			}
		
			theForm.TimedActionStorageDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"TimedActionStorageDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("TimedActionStorageDeleteAll", "");
        }

        #endregion

    };

}
