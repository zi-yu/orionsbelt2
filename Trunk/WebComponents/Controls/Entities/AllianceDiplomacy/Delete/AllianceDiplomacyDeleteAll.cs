
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of AllianceDiplomacy from the data source
    /// </summary>
	public class AllianceDiplomacyDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["AllianceDiplomacyDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["AllianceDiplomacyDeleteAll"] == null ) {
					HttpContext.Current.Items["AllianceDiplomacyDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all AllianceDiplomacy
        /// </summary>
        void DeleteAll ()
        {
			IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:AllianceDiplomacyDeleteAll()'>Delete All</a>");
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
    function AllianceDiplomacyDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from AllianceDiplomacy ?');
			if( !resp ) {
				return;
			}
		
			theForm.AllianceDiplomacyDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"AllianceDiplomacyDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("AllianceDiplomacyDeleteAll", "");
        }

        #endregion

    };

}
