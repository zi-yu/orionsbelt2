
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of CampaignLevel from the data source
    /// </summary>
	public class CampaignLevelDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["CampaignLevelDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["CampaignLevelDeleteAll"] == null ) {
					HttpContext.Current.Items["CampaignLevelDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all CampaignLevel
        /// </summary>
        void DeleteAll ()
        {
			ICampaignLevelPersistance persistance = Persistance.Instance.GetCampaignLevelPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:CampaignLevelDeleteAll()'>Delete All</a>");
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
    function CampaignLevelDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from CampaignLevel ?');
			if( !resp ) {
				return;
			}
		
			theForm.CampaignLevelDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"CampaignLevelDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("CampaignLevelDeleteAll", "");
        }

        #endregion

    };

}
