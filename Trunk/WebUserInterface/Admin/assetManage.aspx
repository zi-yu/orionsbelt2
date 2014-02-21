<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "asset";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:AssetPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:AssetNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:AssetDescriptionSort InnerHtml="Description" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:AssetItem runat="server">
		<tr>
			<td><OrionsBelt:AssetDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AssetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AssetItem>
	</table>
	<OrionsBelt:AssetNumberPagination runat="server" />
	</OrionsBelt:AssetPagedList>

</asp:Content>