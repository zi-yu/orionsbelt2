<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="PrincipalTransactions.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.PrincipalTransactions" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

	<h1><OrionsBelt:Label Key="PrincipalSpends" runat="server" />:</h1>
	
	<OrionsBelt:PrincipalItem Source="QueryString" runat="server">
        <OrionsBeltUI:PrincipalInfoLink runat="server" />
    </OrionsBelt:PrincipalItem>

    <OrionsBelt:TransactionPagedList OrderBy="Tick" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
    <table class="table">
		<tr>
		    <th><OrionsBelt:Label Key="Context" runat="server" /></th>
		    <th><OrionsBelt:Label Key="SpendIdentifier" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Spend" runat="server" /></th>
		    <th><OrionsBelt:Label Key="EarningIdentifier" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Earn" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Tax" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Tick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Date" runat="server" /></th>
		</tr>
		<OrionsBelt:TransactionItem runat="server">
		<tr>
		    <td><OrionsBelt:TransactionTransactionContext runat="server" /></td>
		    <td><OrionsBeltUI:SpendIdentifier runat="server" /></td>
		    <td><OrionsBelt:TransactionCreditsSpend runat="server" /></td>
		    <td><OrionsBeltUI:EarningIdentifier runat="server" /></td>
		    <td><OrionsBelt:TransactionCreditsGain runat="server" /></td>
		    <td><OrionsBeltUI:Tax runat="server" /></td>  
		    <td><OrionsBelt:TransactionTick runat="server" /></td>
		    <td><OrionsBelt:TransactionCreatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:TransactionItem>
	</table>
    </OrionsBelt:TransactionPagedList>

    <h1><OrionsBelt:Label Key="PrincipalEarns" runat="server" />:</h1>
    <OrionsBelt:TransactionPagedList OrderBy="Tick" OrderByParam="desc" ItemsPerPage="50" ID="earns" runat="server" >
    <table class="table">
		<tr>
		    <th><OrionsBelt:Label Key="Context" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Earn" runat="server" /></th>
		    <th><OrionsBelt:Label Key="SpendIdentifier" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Spend" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Tax" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Tick" runat="server" /></th>
		    <th><OrionsBelt:Label Key="Date" runat="server" /></th>
		</tr>
		<OrionsBelt:TransactionItem runat="server">
		<tr>
		    <td><OrionsBelt:TransactionTransactionContext runat="server" /></td>
		    <td><OrionsBelt:TransactionCreditsGain runat="server" /></td>
		    <td><OrionsBeltUI:SpendIdentifier runat="server" /></td>
		    <td><OrionsBelt:TransactionCreditsSpend runat="server" /></td>
		    <td><OrionsBeltUI:Tax runat="server" /></td>  
		    <td><OrionsBelt:TransactionTick runat="server" /></td>
		    <td><OrionsBelt:TransactionCreatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:TransactionItem>
	</table>
    </OrionsBelt:TransactionPagedList>
</asp:Content>