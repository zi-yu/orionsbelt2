<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "auctionhouse";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:AuctionHousePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:AuctionHouseNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:AuctionHouseIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:AuctionHouseCurrentBidSort InnerHtml="CurrentBid" runat="server" /></th>
			<th><OrionsBelt:AuctionHouseDetailsSort InnerHtml="Details" runat="server" /></th>
			<th><OrionsBelt:AuctionHouseBuyedInTickSort InnerHtml="BuyedInTick" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:AuctionHouseItem runat="server">
		<tr>
			<td><OrionsBelt:AuctionHouseId runat="server" /></td>
			<td><OrionsBelt:AuctionHouseCurrentBid runat="server" /></td>
			<td><OrionsBelt:AuctionHouseDetails runat="server" /></td>
			<td><OrionsBelt:AuctionHouseBuyedInTick runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AuctionHouseDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
	<OrionsBelt:AuctionHouseNumberPagination runat="server" />
	</OrionsBelt:AuctionHousePagedList>

</asp:Content>