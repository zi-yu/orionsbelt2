
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an ForumReadMarking object from the data source
    /// </summary>
	public class ForumReadMarkingDelete : BaseFieldControl<ForumReadMarking> {
	
		#region Fields
		
		private string redirectTo;
		private string text = "Delete";
		private bool deleteRelations = true;
		
		#endregion Fields
		
		#region Properties
		
		/// <summary>
        /// URL to follow after deletion
        /// </summary>
		public string OnDeleteRedirectTo {
			get { return redirectTo; }
			set { redirectTo = value; }
		}
		
		/// <summary>
        /// The caption
        /// </summary>
        public string Text {
            get { return text; }
            set { text = value; }
        }
        
        /// <summary>
        /// True if the control should also delete childs
        /// </summary>
        public bool DeleteDirectRelations {
			get { return deleteRelations; }
			set { deleteRelations = value; }
        }
		
		#endregion Properties
	
		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
		}
		
		/// <summary>
        /// OnLoad configuration
        /// </summary>
        /// <param name="e">Event arguments</param>
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if( Page.IsPostBack ) {
				string toRemove = Page.Request.Form["ForumReadMarkingIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["ForumReadMarkingIdToDelete"] == null ) {
					HttpContext.Current.Items["ForumReadMarkingIdToDelete"] = string.Empty;
					DeleteForumReadMarking ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a ForumReadMarking instance from the data source
        /// </summary>
        /// <param name="id">The ForumReadMarking Id</param>
        private void DeleteForumReadMarking ( int id )
        {
			using( IForumReadMarkingPersistance persistance = Persistance.Instance.GetForumReadMarkingPersistance() ) {
				ForumReadMarking entity = persistance.Select(id);
				if( DeleteDirectRelations ) {
					DeleteOneToMany(persistance, entity);
				}
				persistance.Delete(id);
				persistance.Flush();
			}
			
			if( !string.IsNullOrEmpty(OnDeleteRedirectTo) ) {
				Page.Response.Redirect(OnDeleteRedirectTo);
			}
        }
        
        /// <summary>
        /// Deletes a ForumReadMarking's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, ForumReadMarking entity )
        {
        }
		
		#endregion
	
		#region BaseFieldControl<ForumReadMarking> Implementation
		
		/// <summary>
        /// Renders an ForumReadMarking delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The ForumReadMarking instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, ForumReadMarking entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteForumReadMarking({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<ForumReadMarking> Implementation

        #region Delete JS

		/// <summary>
        /// Registers the necessary JavaScript
        /// </summary>
        private void RegisterDeleteJS()
        {
            string script = @"<script type='text/javascript'>
	var theForm = document.forms['" + Page.Form.ClientID + @"'];
    if (!theForm) {
        theForm = document.form;
    }
    function DeleteForumReadMarking ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.ForumReadMarkingIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(ForumReadMarking),"DeleteForumReadMarking", script);
			Page.ClientScript.RegisterHiddenField("ForumReadMarkingIdToDelete", "");
        }

        #endregion

    };

}
