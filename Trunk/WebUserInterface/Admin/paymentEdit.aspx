<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "payment";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PaymentEditor runat="server" Source="QueryString" ID="PaymentEditorId1" >
	<h2>Edit Payment </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PaymentIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PrincipalId</b></td>
			<td>
				<OrionsBelt:PaymentPrincipalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Method</b></td>
			<td>
				<OrionsBelt:PaymentMethodEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Request</b></td>
			<td>
				<OrionsBelt:PaymentRequestEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Response</b></td>
			<td>
				<OrionsBelt:PaymentResponseEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RequestId</b></td>
			<td>
				<OrionsBelt:PaymentRequestIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VerifyState</b></td>
			<td>
				<OrionsBelt:PaymentVerifyStateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Parameters</b></td>
			<td>
				<OrionsBelt:PaymentParametersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ParentPayment</b></td>
			<td>
				<OrionsBelt:PaymentParentPaymentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Ammount</b></td>
			<td>
				<OrionsBelt:PaymentAmmountEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PaymentCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PaymentUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PaymentLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Payment :: Invoice 
		[<a href='/admin/invoiceCreate.aspx?InvoicePaymentEditorFilter=<OrionsBelt:PaymentId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PaymentInvoice runat="server">
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
			<th title="Delete from Payment">Delete</th>
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
	</OrionsBelt:PaymentInvoice>

	<h2>Delete Payment</h2>
	<p><OrionsBelt:PaymentDelete OnDeleteRedirectTo="/admin/paymentManage.aspx" runat="server" /></p>
	
</OrionsBelt:PaymentEditor>
</asp:Content>