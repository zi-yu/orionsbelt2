<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:PrincipalPagedList ItemsPerPage="50" runat="server" >
	<Institutional:PrincipalNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:PrincipalIdSort InnerHtml="Id" runat="server" /></th>
			<th><Institutional:PrincipalNameSort InnerHtml="Name" runat="server" /></th>
			<th><Institutional:PrincipalEmailSort InnerHtml="Email" runat="server" /></th>
			<th><Institutional:PrincipalIpSort InnerHtml="Ip" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:PrincipalItem runat="server">
		<tr>
			<td><Institutional:PrincipalId runat="server" /></td>
			<td><Institutional:PrincipalName runat="server" /></td>
			<td><Institutional:PrincipalEmail runat="server" /></td>
			<td><Institutional:PrincipalIp runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:PrincipalDelete runat="server" /></td>
		</tr>
		</Institutional:PrincipalItem>
	</table>
	<Institutional:PrincipalNumberPagination runat="server" />
	</Institutional:PrincipalPagedList>

</asp:Content>