<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "transaction";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:TransactionEditor runat="server" Source="QueryString" ID="TransactionEditorId1" >
	<h2>Edit Transaction </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:TransactionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TransactionContext</b></td>
			<td>
				<OrionsBelt:TransactionTransactionContextEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PrincipalIdSpend</b></td>
			<td>
				<OrionsBelt:TransactionPrincipalIdSpendEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IdentityTypeSpend</b></td>
			<td>
				<OrionsBelt:TransactionIdentityTypeSpendEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IdentifierSpend</b></td>
			<td>
				<OrionsBelt:TransactionIdentifierSpendEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreditsSpend</b></td>
			<td>
				<OrionsBelt:TransactionCreditsSpendEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SpendCurrentCredits</b></td>
			<td>
				<OrionsBelt:TransactionSpendCurrentCreditsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IdentityTypeGain</b></td>
			<td>
				<OrionsBelt:TransactionIdentityTypeGainEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IdentifierGain</b></td>
			<td>
				<OrionsBelt:TransactionIdentifierGainEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreditsGain</b></td>
			<td>
				<OrionsBelt:TransactionCreditsGainEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GainCurrentCredits</b></td>
			<td>
				<OrionsBelt:TransactionGainCurrentCreditsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tick</b></td>
			<td>
				<OrionsBelt:TransactionTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:TransactionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:TransactionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:TransactionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Transaction :: Invoice 
		[<a href='/admin/invoiceCreate.aspx?InvoiceTransactionEditorFilter=<OrionsBelt:TransactionId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TransactionInvoice runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Identifier</th>
			<th>Name</th>
			<th>Nif</th>
			<th>Money</th>
			<th>Country</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Transaction">Delete</th>
		</tr>
		<OrionsBelt:InvoiceItem runat="server">
		<tr>
			<td><OrionsBelt:InvoiceId runat="server" /></td>
			<td><OrionsBelt:InvoiceIdentifier runat="server" /></td>
			<td><OrionsBelt:InvoiceName runat="server" /></td>
			<td><OrionsBelt:InvoiceNif runat="server" /></td>
			<td><OrionsBelt:InvoiceMoney runat="server" /></td>
			<td><OrionsBelt:InvoiceCountry runat="server" /></td>
			<td><OrionsBelt:InvoiceCreatedDate runat="server" /></td>
			<td><OrionsBelt:InvoiceUpdatedDate runat="server" /></td>
			<td><OrionsBelt:InvoiceLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:InvoiceDelete runat="server" /></td>
		</tr>
		</OrionsBelt:InvoiceItem>
	</table>
	</OrionsBelt:TransactionInvoice>

	<h2>Delete Transaction</h2>
	<p><OrionsBelt:TransactionDelete OnDeleteRedirectTo="/admin/transactionManage.aspx" runat="server" /></p>
	
</OrionsBelt:TransactionEditor>
</asp:Content>