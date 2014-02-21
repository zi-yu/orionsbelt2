<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "server";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:ServerPagedList ItemsPerPage="50" runat="server" >
	<Institutional:ServerNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:ServerIdSort InnerHtml="Id" runat="server" /></th>
			<th><Institutional:ServerNameSort InnerHtml="Name" runat="server" /></th>
			<th><Institutional:ServerUrlSort InnerHtml="Url" runat="server" /></th>
			<th><Institutional:ServerCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><Institutional:ServerUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><Institutional:ServerLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:ServerItem runat="server">
		<tr>
			<td><Institutional:ServerId runat="server" /></td>
			<td><Institutional:ServerName runat="server" /></td>
			<td><Institutional:ServerUrl runat="server" /></td>
			<td><Institutional:ServerCreatedDate runat="server" /></td>
			<td><Institutional:ServerUpdatedDate runat="server" /></td>
			<td><Institutional:ServerLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ServerDelete runat="server" /></td>
		</tr>
		</Institutional:ServerItem>
	</table>
	<Institutional:ServerNumberPagination runat="server" />
	</Institutional:ServerPagedList>

</asp:Content>