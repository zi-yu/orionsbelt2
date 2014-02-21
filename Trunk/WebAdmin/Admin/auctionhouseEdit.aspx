<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "auctionhouse";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:AuctionHouseEditor runat="server" Source="QueryString" ID="AuctionHouseEditorId1" >
	<h2>Edit AuctionHouse &lt;<OrionsBelt:AuctionHouseDetails runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:AuctionHouseIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Price</b></td>
			<td>
				<OrionsBelt:AuctionHousePriceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentBid</b></td>
			<td>
				<OrionsBelt:AuctionHouseCurrentBidEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Buyout</b></td>
			<td>
				<OrionsBelt:AuctionHouseBuyoutEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Begin</b></td>
			<td>
				<OrionsBelt:AuctionHouseBeginEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Timeout</b></td>
			<td>
				<OrionsBelt:AuctionHouseTimeoutEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Quantity</b></td>
			<td>
				<OrionsBelt:AuctionHouseQuantityEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Details</b></td>
			<td>
				<OrionsBelt:AuctionHouseDetailsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ComplexNumber</b></td>
			<td>
				<OrionsBelt:AuctionHouseComplexNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HigherBidOwner</b></td>
			<td>
				<OrionsBelt:AuctionHouseHigherBidOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BuyedInTick</b></td>
			<td>
				<OrionsBelt:AuctionHouseBuyedInTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>OrionsPaid</b></td>
			<td>
				<OrionsBelt:AuctionHouseOrionsPaidEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Advertise</b></td>
			<td>
				<OrionsBelt:AuctionHouseAdvertiseEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:AuctionHouseOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:AuctionHouseCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:AuctionHouseUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:AuctionHouseLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		AuctionHouse :: Bids 
		[<a href='/admin/bidhistoricalCreate.aspx?BidHistoricalResourceEditorFilter=<OrionsBelt:AuctionHouseId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AuctionHouseBids runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Value</th>
			<th>Edit</th>
			<th title="Delete from AuctionHouse">Delete</th>
		</tr>
		<OrionsBelt:BidHistoricalItem runat="server">
		<tr>
			<td><OrionsBelt:BidHistoricalId runat="server" /></td>
			<td><OrionsBelt:BidHistoricalValue runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BidHistoricalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BidHistoricalItem>
	</table>
	</OrionsBelt:AuctionHouseBids>

	<h2>Delete AuctionHouse</h2>
	<p><OrionsBelt:AuctionHouseDelete OnDeleteRedirectTo="/admin/auctionhouseManage.aspx" runat="server" /></p>
	
</OrionsBelt:AuctionHouseEditor>
</asp:Content>