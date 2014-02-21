<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="DiscountBonus.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.DiscountBonus" MasterPageFile="~/Account/BuyOrions.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:InformationBoard runat="server" />
    <OrionsBeltUI:ErrorBoard runat="server" />
    
    <div id='activateKey' class='mediumBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="DiscountBonus" runat="server" /></h2></div>
        <div class='center'>
            <p><OrionsBelt:Label ID="Label5" Key="Code" runat="server"/></p>
            <p><asp:TextBox ID="code" runat="server" /></p>
        </div>
        <div class='bottom'>
            <asp:Button ID="give" OnClick="Discount" CssClass="button" runat="server" />
        </div>
    </div>
    
</asp:Content>