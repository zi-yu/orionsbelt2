﻿
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an Principal object from the data source
    /// </summary>
	public class PrincipalDelete : BaseFieldControl<Principal> {
	
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
				string toRemove = Page.Request.Form["PrincipalIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PrincipalIdToDelete"] == null ) {
					HttpContext.Current.Items["PrincipalIdToDelete"] = string.Empty;
					DeletePrincipal ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a Principal instance from the data source
        /// </summary>
        /// <param name="id">The Principal Id</param>
        private void DeletePrincipal ( int id )
        {
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				Principal entity = persistance.Select(id);
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
        /// Deletes a Principal's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, Principal entity )
        {
			using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance (session) ) {
				foreach( PrincipalTournament son in entity.Tournaments ) {
					persistance.Delete(son);
				}
			}
			
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance (session) ) {
				foreach( Fleet son in entity.Fleets ) {
					persistance.Delete(son);
				}
			}
			
			using( IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance (session) ) {
				foreach( PlayerStorage son in entity.Player ) {
					persistance.Delete(son);
				}
			}
			
			using( IMedalPersistance persistance = Persistance.Instance.GetMedalPersistance (session) ) {
				foreach( Medal son in entity.Medals ) {
					persistance.Delete(son);
				}
			}
			
			using( ICampaignPersistance persistance = Persistance.Instance.GetCampaignPersistance (session) ) {
				foreach( Campaign son in entity.CreatedCampaigns ) {
					persistance.Delete(son);
				}
			}
			
			using( ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance (session) ) {
				foreach( CampaignStatus son in entity.Campaigns ) {
					persistance.Delete(son);
				}
			}
			
			using( IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance (session) ) {
				foreach( BonusCard son in entity.UsedCards ) {
					persistance.Delete(son);
				}
			}
			
			using( IPromotionPersistance persistance = Persistance.Instance.GetPromotionPersistance (session) ) {
				foreach( Promotion son in entity.Promotions ) {
					persistance.Delete(son);
				}
			}
			
			using( IActivatedPromotionPersistance persistance = Persistance.Instance.GetActivatedPromotionPersistance (session) ) {
				foreach( ActivatedPromotion son in entity.ActivePromotions ) {
					persistance.Delete(son);
				}
			}
			
			using( IExceptionInfoPersistance persistance = Persistance.Instance.GetExceptionInfoPersistance (session) ) {
				foreach( ExceptionInfo son in entity.Exceptions ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<Principal> Implementation
		
		/// <summary>
        /// Renders an Principal delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The Principal instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, Principal entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeletePrincipal({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<Principal> Implementation

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
    function DeletePrincipal ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.PrincipalIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(Principal),"DeletePrincipal", script);
			Page.ClientScript.RegisterHiddenField("PrincipalIdToDelete", "");
        }

        #endregion

    };

}
