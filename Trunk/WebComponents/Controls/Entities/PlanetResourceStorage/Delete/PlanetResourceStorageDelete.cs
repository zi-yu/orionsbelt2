
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an PlanetResourceStorage object from the data source
    /// </summary>
	public class PlanetResourceStorageDelete : BaseFieldControl<PlanetResourceStorage> {
	
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
				string toRemove = Page.Request.Form["PlanetResourceStorageIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PlanetResourceStorageIdToDelete"] == null ) {
					HttpContext.Current.Items["PlanetResourceStorageIdToDelete"] = string.Empty;
					DeletePlanetResourceStorage ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a PlanetResourceStorage instance from the data source
        /// </summary>
        /// <param name="id">The PlanetResourceStorage Id</param>
        private void DeletePlanetResourceStorage ( int id )
        {
			using( IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance() ) {
				PlanetResourceStorage entity = persistance.Select(id);
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
        /// Deletes a PlanetResourceStorage's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, PlanetResourceStorage entity )
        {
        }
		
		#endregion
	
		#region BaseFieldControl<PlanetResourceStorage> Implementation
		
		/// <summary>
        /// Renders an PlanetResourceStorage delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The PlanetResourceStorage instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, PlanetResourceStorage entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeletePlanetResourceStorage({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<PlanetResourceStorage> Implementation

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
    function DeletePlanetResourceStorage ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.PlanetResourceStorageIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(PlanetResourceStorage),"DeletePlanetResourceStorage", script);
			Page.ClientScript.RegisterHiddenField("PlanetResourceStorageIdToDelete", "");
        }

        #endregion

    };

}
