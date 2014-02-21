
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an PlayerStorage object from the data source
    /// </summary>
	public class PlayerStorageDelete : BaseFieldControl<PlayerStorage> {
	
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
				string toRemove = Page.Request.Form["PlayerStorageIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["PlayerStorageIdToDelete"] == null ) {
					HttpContext.Current.Items["PlayerStorageIdToDelete"] = string.Empty;
					DeletePlayerStorage ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a PlayerStorage instance from the data source
        /// </summary>
        /// <param name="id">The PlayerStorage Id</param>
        private void DeletePlayerStorage ( int id )
        {
			using( IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance() ) {
				PlayerStorage entity = persistance.Select(id);
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
        /// Deletes a PlayerStorage's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, PlayerStorage entity )
        {
			using( ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance (session) ) {
				foreach( TimedActionStorage son in entity.Actions ) {
					persistance.Delete(son);
				}
			}
			
			using( IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance (session) ) {
				foreach( PlanetStorage son in entity.Planets ) {
					persistance.Delete(son);
				}
			}
			
			using( IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance (session) ) {
				foreach( PlanetResourceStorage son in entity.Resources ) {
					persistance.Delete(son);
				}
			}
			
			using( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance (session) ) {
				foreach( SectorStorage son in entity.Sector ) {
					persistance.Delete(son);
				}
			}
			
			using( IFogOfWarStoragePersistance persistance = Persistance.Instance.GetFogOfWarStoragePersistance (session) ) {
				foreach( FogOfWarStorage son in entity.DiscoveredUniverse ) {
					persistance.Delete(son);
				}
			}
			
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance (session) ) {
				foreach( Fleet son in entity.Fleets ) {
					persistance.Delete(son);
				}
			}
			
			using( IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance (session) ) {
				foreach( UniverseSpecialSector son in entity.SpecialSectores ) {
					persistance.Delete(son);
				}
			}
			
			using( IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance (session) ) {
				foreach( QuestStorage son in entity.Quests ) {
					persistance.Delete(son);
				}
			}
			
			using( IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance (session) ) {
				foreach( BidHistorical son in entity.Bids ) {
					persistance.Delete(son);
				}
			}
			
			using( IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance (session) ) {
				foreach( AuctionHouse son in entity.Auction ) {
					persistance.Delete(son);
				}
			}
			
			using( IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance (session) ) {
				foreach( ArenaStorage son in entity.Arena ) {
					persistance.Delete(son);
				}
			}
			
			using( IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance (session) ) {
				foreach( FriendOrFoe son in entity.MyFriends ) {
					persistance.Delete(son);
				}
			}
			
			using( IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance (session) ) {
				foreach( FriendOrFoe son in entity.OtherFriends ) {
					persistance.Delete(son);
				}
			}
			
			using( IMedalPersistance persistance = Persistance.Instance.GetMedalPersistance (session) ) {
				foreach( Medal son in entity.Medals ) {
					persistance.Delete(son);
				}
			}
			
			using( IPrivateBoardPersistance persistance = Persistance.Instance.GetPrivateBoardPersistance (session) ) {
				foreach( PrivateBoard son in entity.Messages ) {
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
			
			using( IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance (session) ) {
				foreach( Offering son in entity.Forfeit ) {
					persistance.Delete(son);
				}
			}
			
			using( IForumThreadPersistance persistance = Persistance.Instance.GetForumThreadPersistance (session) ) {
				foreach( ForumThread son in entity.Threads ) {
					persistance.Delete(son);
				}
			}
			
			using( IForumPostPersistance persistance = Persistance.Instance.GetForumPostPersistance (session) ) {
				foreach( ForumPost son in entity.Posts ) {
					persistance.Delete(son);
				}
			}
			
			using( IForumReadMarkingPersistance persistance = Persistance.Instance.GetForumReadMarkingPersistance (session) ) {
				foreach( ForumReadMarking son in entity.ReadMarkings ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<PlayerStorage> Implementation
		
		/// <summary>
        /// Renders an PlayerStorage delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The PlayerStorage instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, PlayerStorage entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeletePlayerStorage({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<PlayerStorage> Implementation

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
    function DeletePlayerStorage ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.PlayerStorageIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(PlayerStorage),"DeletePlayerStorage", script);
			Page.ClientScript.RegisterHiddenField("PlayerStorageIdToDelete", "");
        }

        #endregion

    };

}
