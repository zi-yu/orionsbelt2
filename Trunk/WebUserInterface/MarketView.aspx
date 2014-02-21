<%@ Page Language="C#" AutoEventWireup="false" Codebehind="MarketView.aspx.cs" Inherits="OrionsBelt.WebUserInterface.MarketView"
    MasterPageFile="~/OrionsbeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBelt:MarketItem Source="QueryString" runat="server">
        <h1>
            <OrionsBelt:Label Key="Market" runat="server" />:
            <OrionsBelt:MarketName runat="server" />
        </h1>
        <h1>
            <OrionsBelt:Label Key="Coordinate" runat="server" />:
            <OrionsBelt:MarketCoordinates runat="server" />
        </h1>
     </OrionsBelt:MarketItem>
        
    <OrionsBelt:ProductList ID="paged" runat="server" >
    <table id="marketTable" class="table">
	    <tr>
	        <th><OrionsBelt:Label Key="Resource" runat="server" /></th>
	        <th><OrionsBelt:Label Key="AvailableQuantity" runat="server" /></th>
	        <th><OrionsBelt:Label Key="OrionEqualTo" runat="server" /></th>
	    </tr>
	    <OrionsBelt:ProductItem ID="AuctionHouseItem" runat="server">
	    <tr>
	        <td><OrionsBeltUI:MarketProductName runat="server" /></td>
	        <td><OrionsBeltUI:AvailableQuantity runat="server" /></td>
	        <td><OrionsBelt:ProductPrice runat="server" /></td>
	    </tr>
	    </OrionsBelt:ProductItem>
    </table>
    </OrionsBelt:ProductList>
    <h1>
        <OrionsBelt:Label Key="MarketSells" runat="server" />:
    </h1>
    <OrionsBelt:TransactionPagedList OrderBy="Tick" OrderByParam="desc" ItemsPerPage="50" ID="transactions" runat="server" >
    <table class="table">
		<tr>
		    <th><OrionsBelt:Label Key="Context" runat="server" /></th>
		    <th><OrionsBelt:Label Key="SpendIdentifier" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Spend" runat="server" /></th>
		    <th><OrionsBelt:Label Key="EarningIdentifier" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Tick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Date" runat="server" /></th>
		</tr>
		<OrionsBelt:TransactionItem ID="TransactionItem1" runat="server">
		<tr>
		    <td><OrionsBelt:TransactionTransactionContext runat="server" /></td>
		    <td><OrionsBeltUI:SpendIdentifier runat="server" /></td>
		    <td><OrionsBelt:TransactionCreditsSpend runat="server" /></td>
		    <td><OrionsBelt:TransactionIdentityTypeGain runat="server" /></td>
		    <td><OrionsBelt:TransactionTick runat="server" /></td>
		    <td><OrionsBelt:TransactionCreatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:TransactionItem>
	</table>
	</OrionsBelt:TransactionPagedList>
	
	 <OrionsBeltUI:NearMarkets ID="nears" runat="server" />
</asp:Content>
