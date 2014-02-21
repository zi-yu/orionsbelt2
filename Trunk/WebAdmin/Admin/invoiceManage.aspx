<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "invoice";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:InvoicePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:InvoiceNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:InvoiceIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:InvoiceIdentifierSort InnerHtml="Identifier" runat="server" /></th>
			<th><OrionsBelt:InvoiceNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:InvoiceNifSort InnerHtml="Nif" runat="server" /></th>
			<th><OrionsBelt:InvoiceMoneySort InnerHtml="Money" runat="server" /></th>
			<th><OrionsBelt:InvoiceCountrySort InnerHtml="Country" runat="server" /></th>
			<th><OrionsBelt:InvoiceCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:InvoiceUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:InvoiceLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
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
	<OrionsBelt:InvoiceNumberPagination runat="server" />
	</OrionsBelt:InvoicePagedList>

</asp:Content>