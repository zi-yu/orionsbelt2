<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "invoice";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Invoice</h2>
	<p>Use this page to search for objects of the Invoice type.</p>
	<div class="searchTable">
		<OrionsBelt:InvoiceSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:InvoicePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
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
	</OrionsBelt:InvoicePagedList>
</asp:Content>