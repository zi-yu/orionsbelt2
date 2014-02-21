<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyBids.aspx.cs" Inherits="OrionsBelt.WebUserInterface.MyBids"
    MasterPageFile="~/AuctionHouse/Auction.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:AuctionHousePagedList ItemsPerPage="50" ID="paged" runat="server" >
    <div id='auctionHouse' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="MyCurrentBids" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
		        <tr>
		            <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		            <th><OrionsBelt:Label Key="EndTick" runat="server" /></th>
		            <th><OrionsBelt:Label Key="CurrentBid" runat="server" /></th>
		            <th><OrionsBelt:Label Key="NextBid" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Buyout" runat="server" /></th>
		            <th><OrionsBelt:Label Key="HaveLast" runat="server" /></th>
		        </tr>
		        <OrionsBelt:AuctionHouseItem runat="server">
		        <tr>
		            <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		            <td><OrionsBeltUI:AHProductName runat="server" /></td>
		            <td><OrionsBeltUI:Time runat="server" /></td>
		            <td><OrionsBeltUI:AHCurrentBid runat="server" /></td>
		            <td><OrionsBeltUI:AHBid ShowOperator="true" runat="server" /></td>
		            <td><OrionsBeltUI:AHBuyout ShowOperator="true" runat="server" /></td>
		            <td><OrionsBeltUI:LastBid runat="server" /></td>  
		        </tr>
		        </OrionsBelt:AuctionHouseItem>
	        </table>
	    </div>
	    <div class='bottom'></div>
    </div>
    </OrionsBelt:AuctionHousePagedList>
    <OrionsBelt:AuctionHousePagedList ItemsPerPage="50" ID="olds" runat="server" >
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="OldWonBids" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
		<tr>
		    <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		    <th><OrionsBelt:Label Key="BuyedFor" runat="server" /></th>
		    <th><OrionsBelt:Label Key="BuyedAt" runat="server" /></th>
		</tr>
		<OrionsBelt:AuctionHouseItem runat="server">
		<tr>
		    <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		    <td><OrionsBeltUI:AHProductName runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseCurrentBid runat="server" /></td>
		    <td><OrionsBeltUI:AHBuyedAt runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
	    </div>
	    <div class='bottom'></div>
    </div>
    </OrionsBelt:AuctionHousePagedList>
</asp:Content>
