<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddToAuctionAdminAdmin.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AddToAuctionAdmin"
    MasterPageFile="~/AuctionHouse/Auction.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h2>
	    <asp:Literal ID="message" runat="server" />
	</h2>
    <div id='addAuctionHouse' style='margin:10px auto;' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="AddToAuction" runat="server" /></h2></div>
        <div class='center'>
            <dl>
                <dt><OrionsBelt:Label Key="Resource" runat="server" /></dt>
                <dd><asp:DropDownList ID="resources" CssClass="styled" runat="server" /></dd>
                <dt><OrionsBelt:Label Key="Quantity" runat="server" /></dd>
                <dd>
                    <asp:TextBox ID="quantity" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="quantity"
                    ID="quantityRequired" runat="server" />
                </dd>
                <dt><OrionsBelt:Label Key="InitBid" runat="server" /></dt>
                <dd>
                    <asp:TextBox ID="bid" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="bid"
                    ID="bidRequired" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="bid" Display="Dynamic" ID="bidValidator"
                        ValidationExpression="^\d+" runat="server" />
                    <asp:CustomValidator ControlToValidate="bid" Display="Dynamic" 
                        OnServerValidate="ValidateBid" ValidateEmptyText="false" ID="invalidBid" runat="server" />
                </dd>
                <dt><OrionsBelt:Label Key="Buyout" runat="server" /></dt>
                <dd>
                    <asp:TextBox ID="buyout" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="buyout" Display="Dynamic" ID="buyoutValidator"
                        ValidationExpression="^\d+" runat="server" />
                    <asp:CustomValidator ControlToValidate="buyout" Display="Dynamic" 
                        OnServerValidate="ValidateBuyout" ValidateEmptyText="false" ID="invalidBuyout" runat="server" />
                </dd>
                <dt><OrionsBelt:Label Key="SellingTime" runat="server" /></dt>
                <dd><asp:DropDownList ID="times" CssClass="styled" runat="server" /></dd>
            </dl>
        </div>
        <div class='bottom'>
            <asp:Button CausesValidation="true" class='button' OnClick="Send" ID="send" runat="server" />
        </div>
    </div>
    
</asp:Content>
