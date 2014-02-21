
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// AuctionHouse control renderer
    /// </summary>
	public class AuctionHouseItem : BaseEntityItem<AuctionHouse> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AuctionHouseItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAuctionHousePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<AuctionHouse> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Price</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHousePrice () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CurrentBid</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseCurrentBid () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Buyout</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBuyout () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Begin</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBegin () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Timeout</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseTimeout () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Quantity</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseQuantity () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Details</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseDetails () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ComplexNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseComplexNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HigherBidOwner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseHigherBidOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BuyedInTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBuyedInTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>OrionsPaid</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseOrionsPaid () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Advertise</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseAdvertise () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<AuctionHouse> Implementation
		
	};

}
