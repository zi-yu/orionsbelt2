
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of UniverseSpecialSector from the data source
    /// </summary>
	public class UniverseSpecialSectorDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["UniverseSpecialSectorDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["UniverseSpecialSectorDeleteAll"] == null ) {
					HttpContext.Current.Items["UniverseSpecialSectorDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all UniverseSpecialSector
        /// </summary>
        void DeleteAll ()
        {
			IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:UniverseSpecialSectorDeleteAll()'>Delete All</a>");
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
    function UniverseSpecialSectorDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from UniverseSpecialSector ?');
			if( !resp ) {
				return;
			}
		
			theForm.UniverseSpecialSectorDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"UniverseSpecialSectorDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("UniverseSpecialSectorDeleteAll", "");
        }

        #endregion

    };

}
