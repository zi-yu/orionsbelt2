<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddToAuction.aspx.cs" Inherits="OrionsBelt.WebUserInterface.AddToAuction"
    MasterPageFile="~/AuctionHouse/Auction.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:InformationBoard runat="server" />
    <OrionsBeltUI:ErrorBoard runat="server" />
    
    <div class='bigBorderFlat'>
        <div class='top'></div>
        <div class='center'><OrionsBelt:Label Key="SellerRules" runat="server" /></div>
        <div class='bottom'></div>
    </div>
            
    <div style="float:right;margin-right:10px;width:316">
        <OrionsBeltUI:ResourcesViewer runat="server" />
    </div>
    
    <div style="float:left;margin-left:20px">
    <div id='addAuctionHouse' class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="AddToAuction" runat="server" /></h2></div>
        <div class='center'>
            <dl>
                <dt><OrionsBelt:Label Key="Resource" runat="server" /></dt>
                <dd><asp:DropDownList ID="resources" CssClass="styled" runat="server" /><asp:Literal ID="condition" runat="server" /></dd>
                <dt><OrionsBelt:Label Key="Quantity" runat="server" /></dt>
                <dd>
                    <asp:TextBox ID="quantity" runat="server" />
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="quantity"
                    ID="quantityRequired" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="quantity" Display="Dynamic" ID="quantityValidator"
                        ValidationExpression="^\d+" runat="server" />
                        <asp:CustomValidator ControlToValidate="quantity" Display="Dynamic" 
                        OnServerValidate="ValidateQuantity" ValidateEmptyText="false" ID="invalidQuantity" runat="server" />
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
                <dt><OrionsBelt:Label Key="Advertise" runat="server" /></dt>
                <dd>
                    <asp:CheckBox ID="advertise" runat="server" />
                    <asp:CustomValidator ControlToValidate="times" Display="Dynamic" 
                        OnServerValidate="ValidateAdvertising" ID="invalidAdvertising" runat="server" />
                    <OrionsBelt:Label ID="Label1" Key="AdvertiseMessage" runat="server" />
                </dd>
            </dl>
        </div>
        <div class='bottom'>
            <asp:Button CausesValidation="true" CssClass="button" OnClick="Send" ID="send" runat="server" />
        </div>
    </div>
    </div>
  

</asp:Content>
