<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuctionSearch.ascx.cs" Inherits="OrionsBelt.WebUserInterface.Controls.Auction_House.AuctionSearch" %>

<div id='searchAuctionHouse' class='smallBorder'>
    <div class='top'><h2><OrionsBelt:Label Key="SearchOptions" runat="server" /></h2></div>
    <div class='center'>
        <dl>
            <dt><OrionsBelt:Label Key="BidUntil" runat="server" /></dt>
            <dd><asp:TextBox ID="until" runat="server" /><asp:RegularExpressionValidator ControlToValidate="until" Display="Dynamic" ID="untilValidator" ValidationExpression="^\d+" runat="server" /></dd>
            <dt><OrionsBelt:Label Key="BuyoutUntil" runat="server" /></dt>    
            <dd> <asp:TextBox ID="until2" runat="server" />
            <asp:RegularExpressionValidator ControlToValidate="until2" Display="Dynamic" ID="until2Validator" ValidationExpression="^\d+" runat="server" /></dd>
            <dt><OrionsBelt:Label Key="Description" runat="server" /></dt>    
            <dd><OrionsBeltUI:ResourceDropDown ID="typeRes" browserID="typeRes" runat="server" /></dd>
            <dt><OrionsBelt:Label Key="ResourceType" runat="server" /></dt>    
            <dd><OrionsBeltUI:ResourceTypeDropDown ID="groupType" browserID="groupType" runat="server" /></dd>
            <dt><OrionsBelt:Label Key="Race" runat="server" /></dt>    
            <dd><asp:DropDownList ID ="raceChooser" CssClass="styled" runat="server" /></dd>

        </dl>
    </div>
    <div class='bottom'>
        <asp:Button ID="filter" CssClass='button' OnClientClick="AHFilter()" OnClick="Filter" runat="server" />
    </div>
</div>