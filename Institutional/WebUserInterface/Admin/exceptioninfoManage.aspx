<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "exceptioninfo";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:ExceptionInfoPagedList ItemsPerPage="50" runat="server" >
	<Institutional:ExceptionInfoNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:ExceptionInfoIdSort InnerHtml="Id" runat="server" /></th>
			<th><Institutional:ExceptionInfoMessageSort InnerHtml="Message" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:ExceptionInfoItem runat="server">
		<tr>
			<td><Institutional:ExceptionInfoId runat="server" /></td>
			<td><Institutional:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</Institutional:ExceptionInfoItem>
	</table>
	<Institutional:ExceptionInfoNumberPagination runat="server" />
	</Institutional:ExceptionInfoPagedList>

</asp:Content>