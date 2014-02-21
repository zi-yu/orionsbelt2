
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of ForumPost from the data source
    /// </summary>
	public class ForumPostDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["ForumPostDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["ForumPostDeleteAll"] == null ) {
					HttpContext.Current.Items["ForumPostDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all ForumPost
        /// </summary>
        void DeleteAll ()
        {
			IForumPostPersistance persistance = Persistance.Instance.GetForumPostPersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:ForumPostDeleteAll()'>Delete All</a>");
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
    function ForumPostDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from ForumPost ?');
			if( !resp ) {
				return;
			}
		
			theForm.ForumPostDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"ForumPostDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("ForumPostDeleteAll", "");
        }

        #endregion

    };

}
