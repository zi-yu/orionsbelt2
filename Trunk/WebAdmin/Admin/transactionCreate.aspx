<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "transaction";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Transaction</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:TransactionEditor runat="server" Source="New" ID="TransactionEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:TransactionIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TransactionContext</b></td>
			<td><OrionsBelt:TransactionTransactionContextEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PrincipalIdSpend</b></td>
			<td><OrionsBelt:TransactionPrincipalIdSpendEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IdentityTypeSpend</b></td>
			<td><OrionsBelt:TransactionIdentityTypeSpendEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IdentifierSpend</b></td>
			<td><OrionsBelt:TransactionIdentifierSpendEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreditsSpend</b></td>
			<td><OrionsBelt:TransactionCreditsSpendEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SpendCurrentCredits</b></td>
			<td><OrionsBelt:TransactionSpendCurrentCreditsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IdentityTypeGain</b></td>
			<td><OrionsBelt:TransactionIdentityTypeGainEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IdentifierGain</b></td>
			<td><OrionsBelt:TransactionIdentifierGainEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreditsGain</b></td>
			<td><OrionsBelt:TransactionCreditsGainEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GainCurrentCredits</b></td>
			<td><OrionsBelt:TransactionGainCurrentCreditsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Tick</b></td>
			<td><OrionsBelt:TransactionTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:TransactionCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:TransactionUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:TransactionLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:TransactionEditor>
	</table>
	</asp:Content>