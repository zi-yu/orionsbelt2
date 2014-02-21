<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.AHRegist" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1><OrionsBelt:Label Key="AuctionHouseStats" runat="server" />:</h1>
    <br />
	
    <OrionsBelt:AuctionHousePagedList OrderBy="BuyedInTick" OrderByParam="desc" Where="BuyedInTick<>0" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:AuctionHouseNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <table class="table">
		<tr>
		    <th><OrionsBelt:Label Key="Id" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Price" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Buyout" runat="server" /></th>
		    <th><OrionsBelt:Label Key="WinningBid" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Begin" runat="server" /></th>
		    <th><OrionsBelt:Label Key="BuyedInTick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="EndTick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Seller" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Buyer" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Date" runat="server" /></th>
		</tr>
		<OrionsBelt:AuctionHouseItem runat="server">
		<tr>
		    <td><OrionsBeltUI:AHHistoricalLink runat="server" /></td>
		    <td><OrionsBeltUI:AHProductName runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		    <td><OrionsBelt:AuctionHousePrice runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseBuyout runat="server" /></td>
		    <td><OrionsBeltUI:AHWinningBid runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseBegin runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseBuyedInTick runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseTimeout runat="server" /></td>
		    <td><OrionsBeltUI:AuctionHouseSeller ID="seller" runat="server" /></td>
		    <td><OrionsBeltUI:AuctionHouseBuyer ID="buyer" runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseUpdatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
    </OrionsBelt:AuctionHousePagedList>


</asp:Content>