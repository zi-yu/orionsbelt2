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
    /// Deletes all instances of AuctionHouse from the data source
    /// </summary>
	public class AuctionHouseDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["AuctionHouseDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["AuctionHouseDeleteAll"] == null ) {
					HttpContext.Current.Items["AuctionHouseDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all AuctionHouse
        /// </summary>
        void DeleteAll ()
        {
			IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:AuctionHouseDeleteAll()'>Delete All</a>");
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
    function AuctionHouseDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from AuctionHouse ?');
			if( !resp ) {
				return;
			}
		
			theForm.AuctionHouseDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"AuctionHouseDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("AuctionHouseDeleteAll", "");
        }

        #endregion

    };

}
