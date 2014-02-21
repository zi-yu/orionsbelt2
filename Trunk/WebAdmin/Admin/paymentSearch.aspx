<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "payment";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Payment</h2>
	<p>Use this page to search for objects of the Payment type.</p>
	<div class="searchTable">
		<OrionsBelt:PaymentSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PaymentPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>PrincipalId</th>
			<th>Method</th>
			<th>Request</th>
			<th>Response</th>
			<th>RequestId</th>
			<th>VerifyState</th>
			<th>Parameters</th>
			<th>ParentPayment</th>
			<th>Ammount</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:PaymentPagedList>
</asp:Content>