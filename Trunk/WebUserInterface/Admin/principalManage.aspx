<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PrincipalPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PrincipalNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PrincipalNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:PrincipalEmailSort InnerHtml="Email" runat="server" /></th>
			<th><OrionsBelt:PrincipalIpSort InnerHtml="Ip" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PrincipalItem runat="server">
		<tr>
			<td><OrionsBelt:PrincipalName runat="server" /></td>
			<td><OrionsBelt:PrincipalEmail runat="server" /></td>
			<td><OrionsBelt:PrincipalIp runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrincipalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalItem>
	</table>
	<OrionsBelt:PrincipalNumberPagination runat="server" />
	</OrionsBelt:PrincipalPagedList>

</asp:Content>