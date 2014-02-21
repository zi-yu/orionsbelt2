<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Principal</h2>
	<p>Use this page to search for objects of the Principal type.</p>
	<div class="searchTable">
		<OrionsBelt:PrincipalSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PrincipalPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Name</th>
			<th>Email</th>
			<th>Ip</th>
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
	</OrionsBelt:PrincipalPagedList>
</asp:Content>