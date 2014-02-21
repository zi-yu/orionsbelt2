<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "transaction";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Transaction</h2>
	<p>Use this page to search for objects of the Transaction type.</p>
	<div class="searchTable">
		<OrionsBelt:TransactionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:TransactionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>TransactionContext</th>
			<th>PrincipalIdSpend</th>
			<th>IdentityTypeSpend</th>
			<th>IdentifierSpend</th>
			<th>CreditsSpend</th>
			<th>SpendCurrentCredits</th>
			<th>IdentityTypeGain</th>
			<th>IdentifierGain</th>
			<th>CreditsGain</th>
			<th>GainCurrentCredits</th>
			<th>Tick</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:TransactionItem runat="server">
		<tr>
			<td><OrionsBelt:TransactionId runat="server" /></td>
			<td><OrionsBelt:TransactionTransactionContext runat="server" /></td>
			<td><OrionsBelt:TransactionPrincipalIdSpend runat="server" /></td>
			<td><OrionsBelt:TransactionIdentityTypeSpend runat="server" /></td>
			<td><OrionsBelt:TransactionIdentifierSpend runat="server" /></td>
			<td><OrionsBelt:TransactionCreditsSpend runat="server" /></td>
			<td><OrionsBelt:TransactionSpendCurrentCredits runat="server" /></td>
			<td><OrionsBelt:TransactionIdentityTypeGain runat="server" /></td>
			<td><OrionsBelt:TransactionIdentifierGain runat="server" /></td>
			<td><OrionsBelt:TransactionCreditsGain runat="server" /></td>
			<td><OrionsBelt:TransactionGainCurrentCredits runat="server" /></td>
			<td><OrionsBelt:TransactionTick runat="server" /></td>
			<td><OrionsBelt:TransactionCreatedDate runat="server" /></td>
			<td><OrionsBelt:TransactionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TransactionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TransactionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TransactionItem>
	</table>
	</OrionsBelt:TransactionPagedList>
</asp:Content>