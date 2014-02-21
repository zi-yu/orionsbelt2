<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="TopPayments.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.TopPayments" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

	<h1><OrionsBelt:Label Key="Transactions" runat="server" /></h1>
    <OrionsBeltUI:PaymentsPerPrincipal runat="server" />


</asp:Content>