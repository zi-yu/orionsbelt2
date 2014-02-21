
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Deletes an AuctionHouse object from the data source
    /// </summary>
	public class AuctionHouseDelete : BaseFieldControl<AuctionHouse> {
	
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
				string toRemove = Page.Request.Form["AuctionHouseIdToDelete"];
				if( !string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["AuctionHouseIdToDelete"] == null ) {
					HttpContext.Current.Items["AuctionHouseIdToDelete"] = string.Empty;
					DeleteAuctionHouse ( int.Parse(toRemove) );
				}
			}
			RegisterDeleteJS();
        }

		/// <summary>
        /// Deletes a AuctionHouse instance from the data source
        /// </summary>
        /// <param name="id">The AuctionHouse Id</param>
        private void DeleteAuctionHouse ( int id )
        {
			using( IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance() ) {
				AuctionHouse entity = persistance.Select(id);
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
        /// Deletes a AuctionHouse's OneToMany relations from the data source
        /// </summary>
        /// <param name="entity">Target entity</param>
        private void DeleteOneToMany( IPersistanceSession session, AuctionHouse entity )
        {
			using( IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance (session) ) {
				foreach( BidHistorical son in entity.Bids ) {
					persistance.Delete(son);
				}
			}
			
        }
		
		#endregion
	
		#region BaseFieldControl<AuctionHouse> Implementation
		
		/// <summary>
        /// Renders an AuctionHouse delete link
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The AuctionHouse instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop )
		{
            writer.Write("<a href='javascript:DeleteAuctionHouse({0})'>{1}</a>", entity.Id.ToString(), Text);
		}
		
		#endregion BaseFieldControl<AuctionHouse> Implementation

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
    function DeleteAuctionHouse ( id )
    {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
		        theForm.AuctionHouseIdToDelete.value = id;
		        theForm.submit();
		    }
	}
	</script>";
	
			Page.ClientScript.RegisterClientScriptBlock(typeof(AuctionHouse),"DeleteAuctionHouse", script);
			Page.ClientScript.RegisterHiddenField("AuctionHouseIdToDelete", "");
        }

        #endregion

    };

}
