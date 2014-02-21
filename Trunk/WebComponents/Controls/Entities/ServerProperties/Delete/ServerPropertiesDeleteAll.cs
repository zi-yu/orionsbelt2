
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of ServerProperties from the data source
    /// </summary>
	public class ServerPropertiesDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["ServerPropertiesDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["ServerPropertiesDeleteAll"] == null ) {
					HttpContext.Current.Items["ServerPropertiesDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all ServerProperties
        /// </summary>
        void DeleteAll ()
        {
			IServerPropertiesPersistance persistance = Persistance.Instance.GetServerPropertiesPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:ServerPropertiesDeleteAll()'>Delete All</a>");
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
    function ServerPropertiesDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from ServerProperties ?');
			if( !resp ) {
				return;
			}
		
			theForm.ServerPropertiesDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"ServerPropertiesDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("ServerPropertiesDeleteAll", "");
        }

        #endregion

    };

}
