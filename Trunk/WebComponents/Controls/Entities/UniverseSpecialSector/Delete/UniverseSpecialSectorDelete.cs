
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an UniverseSpecialSector object from the data source
    /// </summary>
	public class UniverseSpecialSectorDelete : BaseFieldControl<UniverseSpecialSector> {
	
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
				string toRemove = Page.Request.Form["UniverseSpecialSectorIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["UniverseSpecialSectorIdToDelete"] == null ) {
					HttpContext.Current.Items["UniverseSpecialSectorIdToDelete"] = string.Empty;
					DeleteUniverseSpecialSector ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a UniverseSpecialSector instance from the data source
        /// </summary>
        /// <param name="id">The UniverseSpecialSector Id</param>
        private void DeleteUniverseSpecialSector ( int id )
        {
			using( IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance() ) {
				UniverseSpecialSector entity = persistance.Select(id);
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
        /// Deletes a UniverseSpecialSector's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, UniverseSpecialSector entity )
        {
        }
		
		#endregion
	
		#region BaseFieldControl<UniverseSpecialSector> Implementation
		
		/// <summary>
        /// Renders an UniverseSpecialSector delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The UniverseSpecialSector instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, UniverseSpecialSector entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteUniverseSpecialSector({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<UniverseSpecialSector> Implementation

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
    function DeleteUniverseSpecialSector ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.UniverseSpecialSectorIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(UniverseSpecialSector),"DeleteUniverseSpecialSector", script);
			Page.ClientScript.RegisterHiddenField("UniverseSpecialSectorIdToDelete", "");
        }

        #endregion

    };

}
