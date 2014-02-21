
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of PrincipalTournament from the data source
    /// </summary>
	public class PrincipalTournamentDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["PrincipalTournamentDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PrincipalTournamentDeleteAll"] == null ) {
					HttpContext.Current.Items["PrincipalTournamentDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all PrincipalTournament
        /// </summary>
        void DeleteAll ()
        {
			IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:PrincipalTournamentDeleteAll()'>Delete All</a>");
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
    function PrincipalTournamentDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from PrincipalTournament ?');
			if( !resp ) {
				return;
			}
		
			theForm.PrincipalTournamentDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"PrincipalTournamentDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("PrincipalTournamentDeleteAll", "");
        }

        #endregion

    };

}
