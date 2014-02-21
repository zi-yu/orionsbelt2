<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "exceptioninfo";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ExceptionInfoPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ExceptionInfoNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ExceptionInfoIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ExceptionInfoMessageSort InnerHtml="Message" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ExceptionInfoItem runat="server">
		<tr>
			<td><OrionsBelt:ExceptionInfoId runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ExceptionInfoItem>
	</table>
	<OrionsBelt:ExceptionInfoNumberPagination runat="server" />
	</OrionsBelt:ExceptionInfoPagedList>

</asp:Content>