<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Invoices.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.InvoicesPage" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBelt:InvoiceItem Source="New" runat="server">
    <table >
		<tr>
            <td><OrionsBelt:Label Key="Begin" runat="server" />:</td>
            <td> <OrionsBelt:InvoiceCreatedDateEditor CssClass="styled" ID="begin" runat="server" /></td>
        </tr>
        <tr>
            <td><OrionsBelt:Label Key="End" runat="server" />: </td>
            <td><OrionsBelt:InvoiceUpdatedDateEditor CssClass="styled" ID="end" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="right"><asp:Button CssClass="button" OnClick="Filter" ID="filter" runat="server" /></td>
        </tr>
    </table>
    </OrionsBelt:InvoiceItem>
    
	<OrionsBelt:InvoicePagedList OrderBy="CreatedDate" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:InvoiceNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <table class='table'>
		<tr>
		    <th><OrionsBelt:InvoiceCreatedDateSort ID="sortDate" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Number" runat="server" /></th>
		    <th><OrionsBelt:InvoiceMoneySort ID="sortMoney" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		    <th><OrionsBelt:InvoiceNifSort ID="sortNif" runat="server" /></th>
		    <th><OrionsBelt:InvoiceCountrySort ID="invoiceCountrySort" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Method" runat="server" /></th>
		</tr>
		<OrionsBelt:InvoiceItem runat="server">
		<tr>
		    <td><OrionsBelt:InvoiceCreatedDate runat="server" /></td>
		    <td><OrionsBeltUI:InvoiceIdentifierLink runat="server" /></td>
		    <td><OrionsBeltUI:InvoiceAmmount runat="server" /></td>
		    <td><OrionsBelt:InvoiceName runat="server" /></td>
		    <td><OrionsBelt:InvoiceNif runat="server" /></td>
		    <td><OrionsBeltUI:InvoiceCountryTranslate runat="server" /></td>
		    <td><OrionsBeltUI:PaymentProvider runat="server" /></td>
		</tr>
		</OrionsBelt:InvoiceItem>
	</table>
    </OrionsBelt:InvoicePagedList>

    <asp:Literal ID="groupTable" runat="server" />
</asp:Content>