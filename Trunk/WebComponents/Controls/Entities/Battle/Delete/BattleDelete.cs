
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an Battle object from the data source
    /// </summary>
	public class BattleDelete : BaseFieldControl<Battle> {
	
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
				string toRemove = Page.Request.Form["BattleIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["BattleIdToDelete"] == null ) {
					HttpContext.Current.Items["BattleIdToDelete"] = string.Empty;
					DeleteBattle ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a Battle instance from the data source
        /// </summary>
        /// <param name="id">The Battle Id</param>
        private void DeleteBattle ( int id )
        {
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance() ) {
				Battle entity = persistance.Select(id);
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
        /// Deletes a Battle's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, Battle entity )
        {
			using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance (session) ) {
				foreach( PlayerBattleInformation son in entity.PlayerInformation ) {
					persistance.Delete(son);
				}
			}
			
			using( IBattleExtentionPersistance persistance = Persistance.Instance.GetBattleExtentionPersistance (session) ) {
				foreach( BattleExtention son in entity.BattleExtension ) {
					persistance.Delete(son);
				}
			}
			
			using( ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance (session) ) {
				foreach( TimedActionStorage son in entity.TimedAction ) {
					persistance.Delete(son);
				}
			}
			
			using( ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance (session) ) {
				foreach( CampaignStatus son in entity.Campaigns ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<Battle> Implementation
		
		/// <summary>
        /// Renders an Battle delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The Battle instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, Battle entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteBattle({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<Battle> Implementation

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
    function DeleteBattle ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.BattleIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(Battle),"DeleteBattle", script);
			Page.ClientScript.RegisterHiddenField("BattleIdToDelete", "");
        }

        #endregion

    };

}
