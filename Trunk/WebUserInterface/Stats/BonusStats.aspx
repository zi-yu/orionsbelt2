<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusStats.aspx.cs" Inherits="OrionsBelt.WebUserInterface.BonusStats" MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <p>
	    <OrionsBelt:Label Key="Campaign" runat="server"/>: <asp:DropDownList ID="campaign" runat="server" /> <asp:Button id="generate" OnClick="Generate" CssClass="button" runat="server" />
	</p>
	<h2>
	    <OrionsBelt:Label Key="ExtraInfo" runat="server" />
	</h2>
	<asp:Literal ID="extraInfo" runat="server" />
	<OrionsBelt:BonusCardPagedList ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:BonusCardNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <table class='table'>
		<tr>
		    <th><OrionsBelt:BonusCardTypeSort ID="sortType" runat="server" /></th>
		    <th><OrionsBelt:Label ID="Label1" Key="Code" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Orions" runat="server" /></th>
		    <th><OrionsBelt:BonusCardUsedSort IsAscending="false" ID="sortUsed" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Principal" runat="server" /></th>
		    <th><OrionsBelt:BonusCardCreatedDateSort IsAscending="false" ID="sortDate" runat="server" /></th>
		    <th><OrionsBelt:BonusCardUpdatedDateSort IsAscending="false" ID="sortUpdated" runat="server" /></th>
		</tr>
		<OrionsBelt:BonusCardItem ID="InvoiceItem1" runat="server">
		<tr>
		    <td><OrionsBelt:BonusCardType  runat="server" /></td>
		    <td><OrionsBelt:BonusCardCode runat="server" /></td>
		    <td><OrionsBelt:BonusCardOrions runat="server" /></td>
		    <td><OrionsBeltUI:BonusCardShowUsed runat="server" /></td>
		    <td><OrionsBeltUI:BonusCardPrincipal  runat="server" /></td>
		    <td><OrionsBelt:BonusCardCreatedDate runat="server" /></td>
		    <td><OrionsBelt:BonusCardUpdatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:BonusCardItem>
	</table>
    </OrionsBelt:BonusCardPagedList>

</asp:Content>

