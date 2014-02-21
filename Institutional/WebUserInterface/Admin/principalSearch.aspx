<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
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
		<Institutional:PrincipalSearch runat="server" />
	</div>
	<p/>
	<Institutional:PrincipalPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Email</th>
			<th>Ip</th>
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
	</Institutional:PrincipalPagedList>
</asp:Content>