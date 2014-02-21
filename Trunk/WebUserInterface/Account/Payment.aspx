<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/BuyOrions.Master" 
Inherits="OrionsBelt.WebUserInterface.Account.PaymentPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <asp:Literal id="discloser" runat="server" ></asp:Literal>
    <OrionsBeltUI:PaymentList runat="server" />
    <OrionsBeltUI:PaymentTable runat="server" />
    <div class='clear'></div>
</asp:Content>
