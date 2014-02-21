<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Payments.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.PaymentsPage" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

    
	<OrionsBelt:PaymentPagedList OrderBy="CreatedDate" OrderByParam="desc"  ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:PaymentNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <table class='table'>
		<tr>
		    <th><OrionsBelt:PaymentCreatedDateSort IsAscending="false" ID="sortDate" runat="server" /></th>
		    <th><OrionsBelt:PaymentPrincipalIdSort IsAscending="false" ID="sortName" runat="server" /></th>
		    <th><OrionsBelt:PaymentMethodSort ID="sortMethod" runat="server" /></th>
            <th><OrionsBelt:Label Key="Request" runat="server" /></th>
            <th><OrionsBelt:PaymentVerifyStateSort IsAscending="false" ID="verifyStateSort" runat="server" /></th>
            <th><OrionsBelt:Label Key="Parameters" runat="server" /></th>
             <th><OrionsBelt:Label Key="Amount" runat="server" /></th>
		</tr>
		<OrionsBelt:PaymentItem runat="server">
		<tr>
		    <td><OrionsBelt:PaymentCreatedDate runat="server" /></td>
		    <td><OrionsBeltUI:PayerControl ID="payer" runat="server" /></td>
		    <td><OrionsBelt:PaymentMethod runat="server" /></td>
            <td><OrionsBelt:PaymentRequest runat="server" /></td>
            <td><OrionsBelt:PaymentVerifyState runat="server" /></td>
            <td><OrionsBelt:PaymentParameters runat="server" /></td>
            <td><OrionsBelt:PaymentAmmount runat="server" /></td>
		</tr>
		</OrionsBelt:PaymentItem>
	</table>
    </OrionsBelt:PaymentPagedList>

</asp:Content>