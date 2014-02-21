
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an SectorStorage object from the data source
    /// </summary>
	public class SectorStorageDelete : BaseFieldControl<SectorStorage> {
	
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
				string toRemove = Page.Request.Form["SectorStorageIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["SectorStorageIdToDelete"] == null ) {
					HttpContext.Current.Items["SectorStorageIdToDelete"] = string.Empty;
					DeleteSectorStorage ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a SectorStorage instance from the data source
        /// </summary>
        /// <param name="id">The SectorStorage Id</param>
        private void DeleteSectorStorage ( int id )
        {
			using( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance() ) {
				SectorStorage entity = persistance.Select(id);
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
        /// Deletes a SectorStorage's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, SectorStorage entity )
        {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance (session) ) {
				foreach( Fleet son in entity.Fleets ) {
					persistance.Delete(son);
				}
			}
			
			using( IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance (session) ) {
				foreach( PlanetStorage son in entity.Planets ) {
					persistance.Delete(son);
				}
			}
			
			using( IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance (session) ) {
				foreach( UniverseSpecialSector son in entity.SpecialSectores ) {
					persistance.Delete(son);
				}
			}
			
			using( IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance (session) ) {
				foreach( ArenaStorage son in entity.Arenas ) {
					persistance.Delete(son);
				}
			}
			
			using( IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance (session) ) {
				foreach( Market son in entity.Markets ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<SectorStorage> Implementation
		
		/// <summary>
        /// Renders an SectorStorage delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The SectorStorage instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, SectorStorage entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteSectorStorage({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<SectorStorage> Implementation

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
    function DeleteSectorStorage ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.SectorStorageIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(SectorStorage),"DeleteSectorStorage", script);
			Page.ClientScript.RegisterHiddenField("SectorStorageIdToDelete", "");
        }

        #endregion

    };

}
