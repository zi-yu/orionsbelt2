
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of CampaignStatus from the data source
    /// </summary>
	public class CampaignStatusDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["CampaignStatusDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["CampaignStatusDeleteAll"] == null ) {
					HttpContext.Current.Items["CampaignStatusDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all CampaignStatus
        /// </summary>
        void DeleteAll ()
        {
			ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:CampaignStatusDeleteAll()'>Delete All</a>");
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
    function CampaignStatusDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from CampaignStatus ?');
			if( !resp ) {
				return;
			}
		
			theForm.CampaignStatusDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"CampaignStatusDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("CampaignStatusDeleteAll", "");
        }

        #endregion

    };

}
