﻿
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of PlanetStorage from the data source
    /// </summary>
	public class PlanetStorageDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["PlanetStorageDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PlanetStorageDeleteAll"] == null ) {
					HttpContext.Current.Items["PlanetStorageDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all PlanetStorage
        /// </summary>
        void DeleteAll ()
        {
			IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:PlanetStorageDeleteAll()'>Delete All</a>");
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
    function PlanetStorageDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from PlanetStorage ?');
			if( !resp ) {
				return;
			}
		
			theForm.PlanetStorageDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"PlanetStorageDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("PlanetStorageDeleteAll", "");
        }

        #endregion

    };

}
