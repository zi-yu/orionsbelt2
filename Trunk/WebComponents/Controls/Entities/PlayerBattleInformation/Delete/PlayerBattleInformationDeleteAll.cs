
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of PlayerBattleInformation from the data source
    /// </summary>
	public class PlayerBattleInformationDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["PlayerBattleInformationDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PlayerBattleInformationDeleteAll"] == null ) {
					HttpContext.Current.Items["PlayerBattleInformationDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all PlayerBattleInformation
        /// </summary>
        void DeleteAll ()
        {
			IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:PlayerBattleInformationDeleteAll()'>Delete All</a>");
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
    function PlayerBattleInformationDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from PlayerBattleInformation ?');
			if( !resp ) {
				return;
			}
		
			theForm.PlayerBattleInformationDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"PlayerBattleInformationDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("PlayerBattleInformationDeleteAll", "");
        }

        #endregion

    };

}
