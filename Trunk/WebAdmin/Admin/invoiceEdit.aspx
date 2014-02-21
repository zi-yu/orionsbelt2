<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "invoice";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:InvoiceEditor runat="server" Source="QueryString" ID="InvoiceEditorId1" >
	<h2>Edit Invoice </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:InvoiceIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Identifier</b></td>
			<td>
				<OrionsBelt:InvoiceIdentifierEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:InvoiceNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Nif</b></td>
			<td>
				<OrionsBelt:InvoiceNifEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Money</b></td>
			<td>
				<OrionsBelt:InvoiceMoneyEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Country</b></td>
			<td>
				<OrionsBelt:InvoiceCountryEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Transaction</b></td>
			<td>
				<OrionsBelt:InvoiceTransactionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Payment</b></td>
			<td>
				<OrionsBelt:InvoicePaymentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:InvoiceCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:InvoiceUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:InvoiceLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Invoice</h2>
	<p><OrionsBelt:InvoiceDelete OnDeleteRedirectTo="/admin/invoiceManage.aspx" runat="server" /></p>
	
</OrionsBelt:InvoiceEditor>
</asp:Content>