<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarketControl.ascx.cs" 
Inherits="OrionsBelt.WebUserInterface.Controls.MarketControl" %>

    <OrionsBelt:MarketItem ID="MarketItem1" Source="QueryString" runat="server">
        <h1>
            <OrionsBelt:Label ID="Label1" Key="Market" runat="server" />:
            <OrionsBelt:MarketName ID="MarketName1" runat="server" />
        </h1>
        <h1>
            <OrionsBelt:Label ID="Label2" Key="Coordinate" runat="server" />:
            <OrionsBelt:MarketCoordinates ID="MarketCoordinates1" runat="server" />
        </h1>
     </OrionsBelt:MarketItem>
        
    <OrionsBelt:ProductList ID="paged" runat="server" >
    <table id="marketTable" class="table">
	    <tr>
	        <th><OrionsBelt:Label ID="Label3" Key="Resource" runat="server" /></th>
	        <th><OrionsBelt:Label ID="Label4" Key="AvailableQuantity" runat="server" /></th>
	        <th><OrionsBelt:Label ID="Label5" Key="OrionEqualTo" runat="server" /></th>
	        <th><OrionsBelt:Label ID="Label6" Key="OrionsSpent" runat="server" /></th>
	    </tr>
	    <OrionsBelt:ProductItem ID="AuctionHouseItem" runat="server">
	    <tr>
	        <td><OrionsBeltUI:MarketProductName ID="MarketProductName1" runat="server" /></td>
	        <td><OrionsBeltUI:AvailableQuantity ID="AvailableQuantity1" runat="server" /></td>
	        <td><OrionsBelt:ProductPrice ID="ProductPrice1" runat="server" /></td>
	        <td><OrionsBeltUI:BuyInMarket ID="BuyInMarket1" runat="server" /></td>
	    </tr>
	    </OrionsBelt:ProductItem>
    </table>
    </OrionsBelt:ProductList>
    
    <OrionsBeltUI:TradeRoutes ID="tradeRoutes" runat="server" />
    <OrionsBeltUI:NearMarkets ID="nears" runat="server" />
    <asp:Literal ID="message" runat="server" />
