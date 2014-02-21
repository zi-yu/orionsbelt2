
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// AuctionHouse editor control
    /// </summary>
	public partial class AuctionHouseEditor : BaseEntityEditor<AuctionHouse> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public AuctionHouseEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetAuctionHousePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Price</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHousePriceEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CurrentBid</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseCurrentBidEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Buyout</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBuyoutEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Begin</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBeginEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Timeout</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseTimeoutEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Quantity</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseQuantityEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Details</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseDetailsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ComplexNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseComplexNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HigherBidOwner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseHigherBidOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BuyedInTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseBuyedInTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>OrionsPaid</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseOrionsPaidEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Advertise</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseAdvertiseEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new AuctionHouseLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<AuctionHouse> Implementation
		
	};

}