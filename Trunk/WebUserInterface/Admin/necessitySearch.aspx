<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "necessity";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Necessity</h2>
	<p>Use this page to search for objects of the Necessity type.</p>
	<div class="searchTable">
		<OrionsBelt:NecessitySearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:NecessityPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:NecessityItem runat="server">
		<tr>
			<td><OrionsBelt:NecessityDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:NecessityDelete runat="server" /></td>
		</tr>
		</OrionsBelt:NecessityItem>
	</table>
	</OrionsBelt:NecessityPagedList>
</asp:Content>