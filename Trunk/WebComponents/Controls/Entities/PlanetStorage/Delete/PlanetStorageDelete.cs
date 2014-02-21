
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an PlanetStorage object from the data source
    /// </summary>
	public class PlanetStorageDelete : BaseFieldControl<PlanetStorage> {
	
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
				string toRemove = Page.Request.Form["PlanetStorageIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PlanetStorageIdToDelete"] == null ) {
					HttpContext.Current.Items["PlanetStorageIdToDelete"] = string.Empty;
					DeletePlanetStorage ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a PlanetStorage instance from the data source
        /// </summary>
        /// <param name="id">The PlanetStorage Id</param>
        private void DeletePlanetStorage ( int id )
        {
			using( IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance() ) {
				PlanetStorage entity = persistance.Select(id);
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
        /// Deletes a PlanetStorage's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, PlanetStorage entity )
        {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance (session) ) {
				foreach( Fleet son in entity.Fleets ) {
					persistance.Delete(son);
				}
			}
			
			using( IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance (session) ) {
				foreach( PlanetResourceStorage son in entity.Resources ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<PlanetStorage> Implementation
		
		/// <summary>
        /// Renders an PlanetStorage delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The PlanetStorage instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, PlanetStorage entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeletePlanetStorage({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<PlanetStorage> Implementation

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
    function DeletePlanetStorage ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.PlanetStorageIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(PlanetStorage),"DeletePlanetStorage", script);
			Page.ClientScript.RegisterHiddenField("PlanetStorageIdToDelete", "");
        }

        #endregion

    };

}
