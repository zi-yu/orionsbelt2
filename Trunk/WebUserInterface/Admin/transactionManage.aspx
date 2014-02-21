<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "transaction";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:TransactionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:TransactionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:TransactionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:TransactionTransactionContextSort InnerHtml="TransactionContext" runat="server" /></th>
			<th><OrionsBelt:TransactionPrincipalIdSpendSort InnerHtml="PrincipalIdSpend" runat="server" /></th>
			<th><OrionsBelt:TransactionIdentityTypeSpendSort InnerHtml="IdentityTypeSpend" runat="server" /></th>
			<th><OrionsBelt:TransactionIdentifierSpendSort InnerHtml="IdentifierSpend" runat="server" /></th>
			<th><OrionsBelt:TransactionCreditsSpendSort InnerHtml="CreditsSpend" runat="server" /></th>
			<th><OrionsBelt:TransactionSpendCurrentCreditsSort InnerHtml="SpendCurrentCredits" runat="server" /></th>
			<th><OrionsBelt:TransactionIdentityTypeGainSort InnerHtml="IdentityTypeGain" runat="server" /></th>
			<th><OrionsBelt:TransactionIdentifierGainSort InnerHtml="IdentifierGain" runat="server" /></th>
			<th><OrionsBelt:TransactionCreditsGainSort InnerHtml="CreditsGain" runat="server" /></th>
			<th><OrionsBelt:TransactionGainCurrentCreditsSort InnerHtml="GainCurrentCredits" runat="server" /></th>
			<th><OrionsBelt:TransactionTickSort InnerHtml="Tick" runat="server" /></th>
			<th><OrionsBelt:TransactionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:TransactionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:TransactionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:TransactionNumberPagination runat="server" />
	</OrionsBelt:TransactionPagedList>

</asp:Content>