
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an Fleet object from the data source
    /// </summary>
	public class FleetDelete : BaseFieldControl<Fleet> {
	
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
				string toRemove = Page.Request.Form["FleetIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["FleetIdToDelete"] == null ) {
					HttpContext.Current.Items["FleetIdToDelete"] = string.Empty;
					DeleteFleet ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a Fleet instance from the data source
        /// </summary>
        /// <param name="id">The Fleet Id</param>
        private void DeleteFleet ( int id )
        {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance() ) {
				Fleet entity = persistance.Select(id);
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
        /// Deletes a Fleet's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, Fleet entity )
        {
			using( IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance (session) ) {
				foreach( ArenaStorage son in entity.Arena ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<Fleet> Implementation
		
		/// <summary>
        /// Renders an Fleet delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The Fleet instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, Fleet entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteFleet({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<Fleet> Implementation

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
    function DeleteFleet ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.FleetIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(Fleet),"DeleteFleet", script);
			Page.ClientScript.RegisterHiddenField("FleetIdToDelete", "");
        }

        #endregion

    };

}
