<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "necessity";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:NecessityPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:NecessityNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:NecessityDescriptionSort InnerHtml="Description" runat="server" /></th>
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
	<OrionsBelt:NecessityNumberPagination runat="server" />
	</OrionsBelt:NecessityPagedList>

</asp:Content>