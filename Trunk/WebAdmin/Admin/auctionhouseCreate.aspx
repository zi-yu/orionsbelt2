<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "auctionhouse";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create AuctionHouse</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:AuctionHouseEditor runat="server" Source="New" ID="AuctionHouseEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:AuctionHouseIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Price</b></td>
			<td><OrionsBelt:AuctionHousePriceEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CurrentBid</b></td>
			<td><OrionsBelt:AuctionHouseCurrentBidEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Buyout</b></td>
			<td><OrionsBelt:AuctionHouseBuyoutEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Begin</b></td>
			<td><OrionsBelt:AuctionHouseBeginEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Timeout</b></td>
			<td><OrionsBelt:AuctionHouseTimeoutEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Quantity</b></td>
			<td><OrionsBelt:AuctionHouseQuantityEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Details</b></td>
			<td><OrionsBelt:AuctionHouseDetailsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ComplexNumber</b></td>
			<td><OrionsBelt:AuctionHouseComplexNumberEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>HigherBidOwner</b></td>
			<td><OrionsBelt:AuctionHouseHigherBidOwnerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BuyedInTick</b></td>
			<td><OrionsBelt:AuctionHouseBuyedInTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>OrionsPaid</b></td>
			<td><OrionsBelt:AuctionHouseOrionsPaidEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Advertise</b></td>
			<td><OrionsBelt:AuctionHouseAdvertiseEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Owner</b></td>
			<td><OrionsBelt:AuctionHouseOwnerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:AuctionHouseCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:AuctionHouseUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:AuctionHouseLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseEditor>
	</table>
	</asp:Content>