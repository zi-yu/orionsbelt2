
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that enables AuctionHouse search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a AuctionHousePagedList
    /// </remarks>
	public class AuctionHouseSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox price = new TextBox();
		protected DropDownList operatorsForPrice = new DropDownList();
		protected TextBox currentBid = new TextBox();
		protected DropDownList operatorsForCurrentBid = new DropDownList();
		protected TextBox buyout = new TextBox();
		protected DropDownList operatorsForBuyout = new DropDownList();
		protected TextBox begin = new TextBox();
		protected DropDownList operatorsForBegin = new DropDownList();
		protected TextBox timeout = new TextBox();
		protected DropDownList operatorsForTimeout = new DropDownList();
		protected TextBox quantity = new TextBox();
		protected DropDownList operatorsForQuantity = new DropDownList();
		protected TextBox details = new TextBox();
		protected DropDownList operatorsForDetails = new DropDownList();
		protected TextBox complexNumber = new TextBox();
		protected DropDownList operatorsForComplexNumber = new DropDownList();
		protected TextBox higherBidOwner = new TextBox();
		protected DropDownList operatorsForHigherBidOwner = new DropDownList();
		protected TextBox buyedInTick = new TextBox();
		protected DropDownList operatorsForBuyedInTick = new DropDownList();
		protected TextBox orionsPaid = new TextBox();
		protected DropDownList operatorsForOrionsPaid = new DropDownList();
		protected TextBox advertise = new TextBox();
		protected DropDownList operatorsForAdvertise = new DropDownList();
		protected TextBox createdDate = new TextBox();
		protected DropDownList operatorsForCreatedDate = new DropDownList();
		protected TextBox updatedDate = new TextBox();
		protected DropDownList operatorsForUpdatedDate = new DropDownList();
		protected TextBox lastActionUserId = new TextBox();
		protected DropDownList operatorsForLastActionUserId = new DropDownList();
		protected Button button = new Button();

		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// Search box for AuctionHouse's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Price property
        /// </summary>
		public TextBox Price {
			get { return price; }
			set { price = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Price operators
        /// </summary>
		public DropDownList OperatorsForPrice {
			get { return operatorsForPrice; }
			set { operatorsForPrice = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's CurrentBid property
        /// </summary>
		public TextBox CurrentBid {
			get { return currentBid; }
			set { currentBid = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's CurrentBid operators
        /// </summary>
		public DropDownList OperatorsForCurrentBid {
			get { return operatorsForCurrentBid; }
			set { operatorsForCurrentBid = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Buyout property
        /// </summary>
		public TextBox Buyout {
			get { return buyout; }
			set { buyout = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Buyout operators
        /// </summary>
		public DropDownList OperatorsForBuyout {
			get { return operatorsForBuyout; }
			set { operatorsForBuyout = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Begin property
        /// </summary>
		public TextBox Begin {
			get { return begin; }
			set { begin = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Begin operators
        /// </summary>
		public DropDownList OperatorsForBegin {
			get { return operatorsForBegin; }
			set { operatorsForBegin = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Timeout property
        /// </summary>
		public TextBox Timeout {
			get { return timeout; }
			set { timeout = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Timeout operators
        /// </summary>
		public DropDownList OperatorsForTimeout {
			get { return operatorsForTimeout; }
			set { operatorsForTimeout = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Quantity property
        /// </summary>
		public TextBox Quantity {
			get { return quantity; }
			set { quantity = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Quantity operators
        /// </summary>
		public DropDownList OperatorsForQuantity {
			get { return operatorsForQuantity; }
			set { operatorsForQuantity = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Details property
        /// </summary>
		public TextBox Details {
			get { return details; }
			set { details = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Details operators
        /// </summary>
		public DropDownList OperatorsForDetails {
			get { return operatorsForDetails; }
			set { operatorsForDetails = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's ComplexNumber property
        /// </summary>
		public TextBox ComplexNumber {
			get { return complexNumber; }
			set { complexNumber = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's ComplexNumber operators
        /// </summary>
		public DropDownList OperatorsForComplexNumber {
			get { return operatorsForComplexNumber; }
			set { operatorsForComplexNumber = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's HigherBidOwner property
        /// </summary>
		public TextBox HigherBidOwner {
			get { return higherBidOwner; }
			set { higherBidOwner = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's HigherBidOwner operators
        /// </summary>
		public DropDownList OperatorsForHigherBidOwner {
			get { return operatorsForHigherBidOwner; }
			set { operatorsForHigherBidOwner = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's BuyedInTick property
        /// </summary>
		public TextBox BuyedInTick {
			get { return buyedInTick; }
			set { buyedInTick = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's BuyedInTick operators
        /// </summary>
		public DropDownList OperatorsForBuyedInTick {
			get { return operatorsForBuyedInTick; }
			set { operatorsForBuyedInTick = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's OrionsPaid property
        /// </summary>
		public TextBox OrionsPaid {
			get { return orionsPaid; }
			set { orionsPaid = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's OrionsPaid operators
        /// </summary>
		public DropDownList OperatorsForOrionsPaid {
			get { return operatorsForOrionsPaid; }
			set { operatorsForOrionsPaid = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's Advertise property
        /// </summary>
		public TextBox Advertise {
			get { return advertise; }
			set { advertise = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's Advertise operators
        /// </summary>
		public DropDownList OperatorsForAdvertise {
			get { return operatorsForAdvertise; }
			set { operatorsForAdvertise = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for AuctionHouse's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for AuctionHouse's LastActionUserId operators
        /// </summary>
		public DropDownList OperatorsForLastActionUserId {
			get { return operatorsForLastActionUserId; }
			set { operatorsForLastActionUserId = value; }
		}
		
		#endregion Control Properties
		
		#region Control Events
		
		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			EnsureChildControls();
			button.Text = "Search";
		}
		
		/// <summary>
        /// Control actions
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnLoad( EventArgs args )
		{
			base.OnLoad(args);
			if( Page.IsPostBack ) {
				StringWriter writer = new StringWriter();
				bool first = true;
				
				if( !string.IsNullOrEmpty( Id.Text ) ) {
					writer.Write( "{2} e.Id {0} '{1}' ",
							operatorsForId.SelectedValue, 
							Id.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Price.Text ) ) {
					writer.Write( "{2} e.Price {0} '{1}' ",
							operatorsForPrice.SelectedValue, 
							Price.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CurrentBid.Text ) ) {
					writer.Write( "{2} e.CurrentBid {0} '{1}' ",
							operatorsForCurrentBid.SelectedValue, 
							CurrentBid.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Buyout.Text ) ) {
					writer.Write( "{2} e.Buyout {0} '{1}' ",
							operatorsForBuyout.SelectedValue, 
							Buyout.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Begin.Text ) ) {
					writer.Write( "{2} e.Begin {0} '{1}' ",
							operatorsForBegin.SelectedValue, 
							Begin.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Timeout.Text ) ) {
					writer.Write( "{2} e.Timeout {0} '{1}' ",
							operatorsForTimeout.SelectedValue, 
							Timeout.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Quantity.Text ) ) {
					writer.Write( "{2} e.Quantity {0} '{1}' ",
							operatorsForQuantity.SelectedValue, 
							Quantity.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Details.Text ) ) {
					writer.Write( "{2} e.Details {0} '{1}' ",
							operatorsForDetails.SelectedValue, 
							Details.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ComplexNumber.Text ) ) {
					writer.Write( "{2} e.ComplexNumber {0} '{1}' ",
							operatorsForComplexNumber.SelectedValue, 
							ComplexNumber.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HigherBidOwner.Text ) ) {
					writer.Write( "{2} e.HigherBidOwner {0} '{1}' ",
							operatorsForHigherBidOwner.SelectedValue, 
							HigherBidOwner.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BuyedInTick.Text ) ) {
					writer.Write( "{2} e.BuyedInTick {0} '{1}' ",
							operatorsForBuyedInTick.SelectedValue, 
							BuyedInTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( OrionsPaid.Text ) ) {
					writer.Write( "{2} e.OrionsPaid {0} '{1}' ",
							operatorsForOrionsPaid.SelectedValue, 
							OrionsPaid.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Advertise.Text ) ) {
					writer.Write( "{2} e.Advertise {0} '{1}' ",
							operatorsForAdvertise.SelectedValue, 
							Advertise.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreatedDate.Text ) ) {
					writer.Write( "{2} e.CreatedDate {0} '{1}' ",
							operatorsForCreatedDate.SelectedValue, 
							CreatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UpdatedDate.Text ) ) {
					writer.Write( "{2} e.UpdatedDate {0} '{1}' ",
							operatorsForUpdatedDate.SelectedValue, 
							UpdatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastActionUserId.Text ) ) {
					writer.Write( "{2} e.LastActionUserId {0} '{1}' ",
							operatorsForLastActionUserId.SelectedValue, 
							LastActionUserId.Text, first ? "" : ","
						);
					first = false;
				}

				string search = writer.ToString();
				if( !string.IsNullOrEmpty(search) ) {
					HttpContext.Current.Items[BasePagedList<AuctionHouse>.GetWhereKey("AuctionHouse")] = writer.ToString();
				}
			}
		}
		
		/// <summary>
        /// Creates the control tree
        /// </summary>
		protected override void CreateChildControls()
        {
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th>Field</th><th>Operator</th><th>Search</th></tr>") );
			Id.ID = "searchId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Id</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Id );
			Controls.Add( new LiteralControl("</td><tr>") );
			Price.ID = "searchPrice";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Price</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPrice ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Price );
			Controls.Add( new LiteralControl("</td><tr>") );
			CurrentBid.ID = "searchCurrentBid";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CurrentBid</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrentBid ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CurrentBid );
			Controls.Add( new LiteralControl("</td><tr>") );
			Buyout.ID = "searchBuyout";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Buyout</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBuyout ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Buyout );
			Controls.Add( new LiteralControl("</td><tr>") );
			Begin.ID = "searchBegin";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Begin</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBegin ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Begin );
			Controls.Add( new LiteralControl("</td><tr>") );
			Timeout.ID = "searchTimeout";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Timeout</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTimeout ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Timeout );
			Controls.Add( new LiteralControl("</td><tr>") );
			Quantity.ID = "searchQuantity";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Quantity</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuantity ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Quantity );
			Controls.Add( new LiteralControl("</td><tr>") );
			Details.ID = "searchDetails";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Details</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDetails ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Details );
			Controls.Add( new LiteralControl("</td><tr>") );
			ComplexNumber.ID = "searchComplexNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ComplexNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForComplexNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ComplexNumber );
			Controls.Add( new LiteralControl("</td><tr>") );
			HigherBidOwner.ID = "searchHigherBidOwner";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HigherBidOwner</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHigherBidOwner ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HigherBidOwner );
			Controls.Add( new LiteralControl("</td><tr>") );
			BuyedInTick.ID = "searchBuyedInTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BuyedInTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBuyedInTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BuyedInTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			OrionsPaid.ID = "searchOrionsPaid";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>OrionsPaid</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOrionsPaid ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( OrionsPaid );
			Controls.Add( new LiteralControl("</td><tr>") );
			Advertise.ID = "searchAdvertise";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Advertise</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAdvertise ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Advertise );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreatedDate.ID = "searchCreatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			UpdatedDate.ID = "searchUpdatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UpdatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUpdatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UpdatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastActionUserId.ID = "searchLastActionUserId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastActionUserId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastActionUserId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastActionUserId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Controls.Add( new LiteralControl("<tr><td></td><td></td><td>") );
			Controls.Add( button );
			Controls.Add( new LiteralControl("</td></tr>") );
			Controls.Add( new LiteralControl("</table>") );
        }
		
		#endregion Control Events
		
		#region Utilities
		
		/// <summary>
        /// Adds Search operators
        /// </summary>
        /// <param name="list">The Target List</param>
        /// <returns>The target list</returns>
		private DropDownList AddOperators( DropDownList list )
		{
			list.Items.Add( "=" );
			list.Items.Add( "!=" );
			list.Items.Add( "<" );
			list.Items.Add( ">" );
			list.Items.Add( "<=" );
			list.Items.Add( ">=" );
			list.Items.Add( "like" );
			list.Items.Add( "not like" );
			
			return list;
		}
		
		#endregion Utilities
	
	};

}
