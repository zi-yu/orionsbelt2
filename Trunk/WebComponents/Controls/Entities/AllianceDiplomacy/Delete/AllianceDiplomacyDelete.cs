
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an AllianceDiplomacy object from the data source
    /// </summary>
	public class AllianceDiplomacyDelete : BaseFieldControl<AllianceDiplomacy> {
	
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
				string toRemove = Page.Request.Form["AllianceDiplomacyIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["AllianceDiplomacyIdToDelete"] == null ) {
					HttpContext.Current.Items["AllianceDiplomacyIdToDelete"] = string.Empty;
					DeleteAllianceDiplomacy ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a AllianceDiplomacy instance from the data source
        /// </summary>
        /// <param name="id">The AllianceDiplomacy Id</param>
        private void DeleteAllianceDiplomacy ( int id )
        {
			using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance() ) {
				AllianceDiplomacy entity = persistance.Select(id);
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
        /// Deletes a AllianceDiplomacy's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, AllianceDiplomacy entity )
        {
        }
		
		#endregion
	
		#region BaseFieldControl<AllianceDiplomacy> Implementation
		
		/// <summary>
        /// Renders an AllianceDiplomacy delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The AllianceDiplomacy instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, AllianceDiplomacy entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteAllianceDiplomacy({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<AllianceDiplomacy> Implementation

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
    function DeleteAllianceDiplomacy ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.AllianceDiplomacyIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(AllianceDiplomacy),"DeleteAllianceDiplomacy", script);
			Page.ClientScript.RegisterHiddenField("AllianceDiplomacyIdToDelete", "");
        }

        #endregion

    };

}
