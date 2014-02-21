<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="AuctionAdmin.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AuctionAdmin" MasterPageFile="~/AuctionHouse/Auction.Master" %>
<%@ Register TagPrefix="AU" TagName="Searcher" Src="~/Controls/Auction House/AuctionSearch.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <asp:Literal ID="message" runat="server" />

	<AU:Searcher ID="search" runat="server" />
	
	<OrionsBelt:AuctionHousePagedList Where="BuyedInTick=0 and Buyout<>0 and Price=CurrentBid" ItemsPerPage="50" ID="paged" runat="server" >
	<OrionsBelt:AuctionHouseNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <div id='auctionHouse' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="AuctionHouse" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		            <th><OrionsBelt:Label Key="EndTick" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Owner" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Buyout" runat="server" /></th>
        		    
		        </tr>
		        <OrionsBelt:AuctionHouseItem runat="server">
		        <tr>
		            <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		            <td><OrionsBelt:AuctionHouseDetails runat="server" /></td>
		            <td><OrionsBeltUI:Time runat="server" /></td>
		            <td><OrionsBelt:AuctionHouseOwner runat="server" /></td>
		            <td><OrionsBeltUI:AHAdminBuyout runat="server" /></td>
		        </tr>
		        </OrionsBelt:AuctionHouseItem>
	        </table>
        </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:AuctionHouseNumberPagination ItemsPerPage="50" runat="server" />
    </OrionsBelt:AuctionHousePagedList>
    
    
    
</asp:Content>