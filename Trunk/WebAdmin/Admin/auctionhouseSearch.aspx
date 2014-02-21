<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "auctionhouse";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search AuctionHouse</h2>
	<p>Use this page to search for objects of the AuctionHouse type.</p>
	<div class="searchTable">
		<OrionsBelt:AuctionHouseSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:AuctionHousePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>CurrentBid</th>
			<th>Details</th>
			<th>BuyedInTick</th>
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
	</OrionsBelt:AuctionHousePagedList>
</asp:Content>