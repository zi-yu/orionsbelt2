<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="AuctionHouse.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.AuctionHousePage" MasterPageFile="~/AuctionHouse/Auction.Master" %>
<%@ Register TagPrefix="AU" TagName="Searcher" Src="~/Controls/Auction House/AuctionSearch.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBeltUI:ErrorBoard  runat="server" />
    <OrionsBeltUI:InformationBoard runat="server" />
	<AU:Searcher ID="search" runat="server" />
	
	<OrionsBelt:AuctionHousePagedList OrderBy="CreatedDate" OrderByParam="desc" Where="BuyedInTick=0" ItemsPerPage="25" ID="paged" runat="server" >
    <OrionsBelt:AuctionHouseNumberPagination ItemsPerPage="25" ID="pagination" runat="server" />
     <div id='auctionHouse' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="AuctionHouse" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		            <th><OrionsBelt:AuctionHouseTimeoutSort ID="sortTime" runat="server" /></th>
		            <th><OrionsBelt:Label Key="CurrentBid" runat="server" /></th>
		            <th><OrionsBelt:AuctionHouseCurrentBidSort ID="sortBid" runat="server" /></th>
		            <th>
		                <OrionsBelt:AuctionHouseBuyoutSort ID="sortBuyout" runat="server" />
		            </th>
		            <OrionsBelt:RoleVisible Role="admin" runat="server">
		                <th><OrionsBelt:Label Key="Buyer" runat="server" /></th>
		                <th><OrionsBelt:Label Key="Seller" runat="server" /></th>
		            </OrionsBelt:RoleVisible>
		        </tr>
		        <OrionsBelt:AuctionHouseItem runat="server">
		        <tr <OrionsBeltUI:AHMybid runat="server" />>
		            <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		            <td><OrionsBeltUI:AHProductName runat="server" /></td>
		            <td><OrionsBeltUI:Time runat="server" /></td>
		            <td><OrionsBeltUI:AHCurrentBid runat="server" /></td>
		            <td><OrionsBeltUI:AHBid ShowOperator="true" runat="server" /></td>
		            <td><OrionsBeltUI:AHBuyout ShowOperator="true" runat="server" /></td>
		            <OrionsBelt:RoleVisible Role="admin" runat="server">
		                <td><OrionsBeltUI:AHBuyer runat="server" /></td>
		                <td><OrionsBeltUI:AHSeller runat="server" /></td>
		            </OrionsBelt:RoleVisible>
		        </tr>
		        </OrionsBelt:AuctionHouseItem>
	        </table>
        </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:AuctionHouseNumberPagination ItemsPerPage="25" ID="AuctionHouseNumberPagination1" runat="server" />
    </OrionsBelt:AuctionHousePagedList>
    
    
</asp:Content>