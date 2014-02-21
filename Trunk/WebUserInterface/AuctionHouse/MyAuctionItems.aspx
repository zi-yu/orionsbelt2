<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyAuctionItems.aspx.cs" Inherits="OrionsBelt.WebUserInterface.MyAuctionItems"
    MasterPageFile="~/AuctionHouse/Auction.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:AuctionHousePagedList ItemsPerPage="50" ID="paged" runat="server" >
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="MyAuctionItems" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
		<tr>
		    <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		    <th><OrionsBelt:Label Key="EndTick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="CurrentBid" runat="server" /></th>
		    <th><OrionsBelt:Label Key="NextBid" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Buyout" runat="server" /></th>
		</tr>
		<OrionsBelt:AuctionHouseItem ID="AuctionHouseItem1" runat="server">
		<tr>
		    <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		    <td><OrionsBeltUI:AHProductName runat="server" /></td>
		    <td><OrionsBeltUI:RealTime runat="server" /></td>
		    <td><OrionsBeltUI:AHCurrentBid runat="server" /></td>
		    <td><OrionsBeltUI:AHBid ShowOperator="false" runat="server" /></td>
		    <td><OrionsBeltUI:AHBuyout ShowOperator="false" runat="server" /></td>  
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
	    </div>
        <div class='bottom'></div>
    </div>
    </OrionsBelt:AuctionHousePagedList>
    <OrionsBelt:AuctionHousePagedList OrderByParam="desc" OrderBy="BuyedInTick" ItemsPerPage="50" ID="olds" runat="server" >
     <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="OldAuctionItems" runat="server" /></h2></div>
        <div class='center'>
            <table class="newtable">
		<tr>
		    <th><OrionsBelt:Label Key="Quantity" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Description" runat="server" /></th>
		    <th><OrionsBelt:Label Key="WonOrions" runat="server" /></th>
		    <th><OrionsBelt:Label Key="SoldAt" runat="server" /></th>
		</tr>
		<OrionsBelt:AuctionHouseItem runat="server">
		<tr>
		    <td><OrionsBelt:AuctionHouseQuantity runat="server" /></td>
		    <td><OrionsBeltUI:AHProductName runat="server" /></td>
		    <td><OrionsBelt:AuctionHouseOrionsPaid runat="server" /></td>
		    <td><OrionsBeltUI:AHBuyedAt runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
	    </div>
        <div class='bottom'></div>
    </div>
    </OrionsBelt:AuctionHousePagedList>
</asp:Content>
