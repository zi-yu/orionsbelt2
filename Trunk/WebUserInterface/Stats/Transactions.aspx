<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Transactions.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Transactions" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

	<h1><OrionsBelt:Label Key="Transactions" runat="server" /></h1>
    <OrionsBeltUI:TransactionsList runat="server" />


</asp:Content>