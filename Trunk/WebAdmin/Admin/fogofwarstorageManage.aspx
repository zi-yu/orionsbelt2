<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fogofwarstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:FogOfWarStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:FogOfWarStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:FogOfWarStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:FogOfWarStorageSystemXSort InnerHtml="SystemX" runat="server" /></th>
			<th><OrionsBelt:FogOfWarStorageSystemYSort InnerHtml="SystemY" runat="server" /></th>
			<th><OrionsBelt:FogOfWarStorageHasDiscoveredAllSort InnerHtml="HasDiscoveredAll" runat="server" /></th>
			<th><OrionsBelt:FogOfWarStorageHasDiscoveredHalfSort InnerHtml="HasDiscoveredHalf" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:FogOfWarStorageItem runat="server">
		<tr>
			<td><OrionsBelt:FogOfWarStorageId runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageSystemX runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageSystemY runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageHasDiscoveredAll runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageHasDiscoveredHalf runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FogOfWarStorageItem>
	</table>
	<OrionsBelt:FogOfWarStorageNumberPagination runat="server" />
	</OrionsBelt:FogOfWarStoragePagedList>

</asp:Content>