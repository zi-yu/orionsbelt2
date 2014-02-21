<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "payment";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PaymentPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PaymentNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PaymentIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PaymentPrincipalIdSort InnerHtml="PrincipalId" runat="server" /></th>
			<th><OrionsBelt:PaymentMethodSort InnerHtml="Method" runat="server" /></th>
			<th><OrionsBelt:PaymentRequestSort InnerHtml="Request" runat="server" /></th>
			<th><OrionsBelt:PaymentResponseSort InnerHtml="Response" runat="server" /></th>
			<th><OrionsBelt:PaymentRequestIdSort InnerHtml="RequestId" runat="server" /></th>
			<th><OrionsBelt:PaymentVerifyStateSort InnerHtml="VerifyState" runat="server" /></th>
			<th><OrionsBelt:PaymentParametersSort InnerHtml="Parameters" runat="server" /></th>
			<th><OrionsBelt:PaymentParentPaymentSort InnerHtml="ParentPayment" runat="server" /></th>
			<th><OrionsBelt:PaymentAmmountSort InnerHtml="Ammount" runat="server" /></th>
			<th><OrionsBelt:PaymentCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PaymentUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PaymentLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PaymentItem runat="server">
		<tr>
			<td><OrionsBelt:PaymentId runat="server" /></td>
			<td><OrionsBelt:PaymentPrincipalId runat="server" /></td>
			<td><OrionsBelt:PaymentMethod runat="server" /></td>
			<td><OrionsBelt:PaymentRequest runat="server" /></td>
			<td><OrionsBelt:PaymentResponse runat="server" /></td>
			<td><OrionsBelt:PaymentRequestId runat="server" /></td>
			<td><OrionsBelt:PaymentVerifyState runat="server" /></td>
			<td><OrionsBelt:PaymentParameters runat="server" /></td>
			<td><OrionsBelt:PaymentParentPayment runat="server" /></td>
			<td><OrionsBelt:PaymentAmmount runat="server" /></td>
			<td><OrionsBelt:PaymentCreatedDate runat="server" /></td>
			<td><OrionsBelt:PaymentUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PaymentLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PaymentDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PaymentItem>
	</table>
	<OrionsBelt:PaymentNumberPagination runat="server" />
	</OrionsBelt:PaymentPagedList>

</asp:Content>