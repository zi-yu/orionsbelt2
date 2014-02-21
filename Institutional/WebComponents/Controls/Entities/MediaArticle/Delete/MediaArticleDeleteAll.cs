
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Deletes all instances of MediaArticle from the data source
    /// </summary>
	public class MediaArticleDeleteAll : Control {
	
		#region Control Fields & Events
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["MediaArticleDeleteAll"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["MediaArticleDeleteAll"] == null ) {
					HttpContext.Current.Items["MediaArticleDeleteAll"] = string.Empty;
					DeleteAll();
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes all MediaArticle
        /// </summary>
        void DeleteAll ()
        {
			IMediaArticlePersistance persistance = Persistance.Instance.GetMediaArticlePersistance();
			persistance.DeleteAll();
			persistance.Flush();
        }
		
		#endregion
	
		#region Control Implementation
		
		protected override void Render( HtmlTextWriter writer )
		{
            writer.Write("<a href='javascript:MediaArticleDeleteAll()'>Delete All</a>");
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
    function MediaArticleDeleteAll ()
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
			var resp = confirm('Really delete all from MediaArticle ?');
			if( !resp ) {
				return;
			}
		
			theForm.MediaArticleDeleteAll.value = 1;
			theForm.submit();
		}
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(GetType(),"MediaArticleDeleteAll", script);
			Page.ClientScript.RegisterHiddenField("MediaArticleDeleteAll", "");
        }

        #endregion

    };

}
