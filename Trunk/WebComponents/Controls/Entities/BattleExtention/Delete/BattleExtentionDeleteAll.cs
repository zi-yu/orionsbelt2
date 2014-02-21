
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of BattleExtention from the data source
    /// </summary>
	public class BattleExtentionDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["BattleExtentionDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["BattleExtentionDeleteAll"] == null ) {
					HttpContext.Current.Items["BattleExtentionDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all BattleExtention
        /// </summary>
        void DeleteAll ()
        {
			IBattleExtentionPersistance persistance = Persistance.Instance.GetBattleExtentionPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:BattleExtentionDeleteAll()'>Delete All</a>");
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
    function BattleExtentionDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from BattleExtention ?');
			if( !resp ) {
				return;
			}
		
			theForm.BattleExtentionDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"BattleExtentionDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("BattleExtentionDeleteAll", "");
        }

        #endregion

    };

}
