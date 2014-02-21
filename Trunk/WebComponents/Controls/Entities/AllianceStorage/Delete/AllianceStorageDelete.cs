
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an AllianceStorage object from the data source
    /// </summary>
	public class AllianceStorageDelete : BaseFieldControl<AllianceStorage> {
	
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
				string toRemove = Page.Request.Form["AllianceStorageIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["AllianceStorageIdToDelete"] == null ) {
					HttpContext.Current.Items["AllianceStorageIdToDelete"] = string.Empty;
					DeleteAllianceStorage ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a AllianceStorage instance from the data source
        /// </summary>
        /// <param name="id">The AllianceStorage Id</param>
        private void DeleteAllianceStorage ( int id )
        {
			using( IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance() ) {
				AllianceStorage entity = persistance.Select(id);
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
        /// Deletes a AllianceStorage's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, AllianceStorage entity )
        {
			using( IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance (session) ) {
				foreach( PlayerStorage son in entity.Players ) {
					persistance.Delete(son);
				}
			}
			
			using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance (session) ) {
				foreach( AllianceDiplomacy son in entity.DiplomacyA ) {
					persistance.Delete(son);
				}
			}
			
			using( IAllianceDiplomacyPersistance persistance = Persistance.Instance.GetAllianceDiplomacyPersistance (session) ) {
				foreach( AllianceDiplomacy son in entity.DiplomacyB ) {
					persistance.Delete(son);
				}
			}
			
			using( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance (session) ) {
				foreach( SectorStorage son in entity.Sector ) {
					persistance.Delete(son);
				}
			}
			
			using( IAssetPersistance persistance = Persistance.Instance.GetAssetPersistance (session) ) {
				foreach( Asset son in entity.Assets ) {
					persistance.Delete(son);
				}
			}
			
			using( INecessityPersistance persistance = Persistance.Instance.GetNecessityPersistance (session) ) {
				foreach( Necessity son in entity.Necessities ) {
					persistance.Delete(son);
				}
			}
			
			using( IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance (session) ) {
				foreach( Offering son in entity.Offerings ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<AllianceStorage> Implementation
		
		/// <summary>
        /// Renders an AllianceStorage delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The AllianceStorage instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, AllianceStorage entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteAllianceStorage({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<AllianceStorage> Implementation

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
    function DeleteAllianceStorage ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.AllianceStorageIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(AllianceStorage),"DeleteAllianceStorage", script);
			Page.ClientScript.RegisterHiddenField("AllianceStorageIdToDelete", "");
        }

        #endregion

    };

}
