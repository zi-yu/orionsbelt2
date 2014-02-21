
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an Tournament object from the data source
    /// </summary>
	public class TournamentDelete : BaseFieldControl<Tournament> {
	
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
				string toRemove = Page.Request.Form["TournamentIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["TournamentIdToDelete"] == null ) {
					HttpContext.Current.Items["TournamentIdToDelete"] = string.Empty;
					DeleteTournament ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a Tournament instance from the data source
        /// </summary>
        /// <param name="id">The Tournament Id</param>
        private void DeleteTournament ( int id )
        {
			using( ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance() ) {
				Tournament entity = persistance.Select(id);
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
        /// Deletes a Tournament's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, Tournament entity )
        {
			using( IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance (session) ) {
				foreach( PlayersGroupStorage son in entity.Groups ) {
					persistance.Delete(son);
				}
			}
			
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance (session) ) {
				foreach( Battle son in entity.Battles ) {
					persistance.Delete(son);
				}
			}
			
			using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance (session) ) {
				foreach( PrincipalTournament son in entity.Regists ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<Tournament> Implementation
		
		/// <summary>
        /// Renders an Tournament delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The Tournament instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, Tournament entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteTournament({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<Tournament> Implementation

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
    function DeleteTournament ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.TournamentIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(Tournament),"DeleteTournament", script);
			Page.ClientScript.RegisterHiddenField("TournamentIdToDelete", "");
        }

        #endregion

    };

}
