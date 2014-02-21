<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fogofwarstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search FogOfWarStorage</h2>
	<p>Use this page to search for objects of the FogOfWarStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:FogOfWarStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:FogOfWarStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>HasDiscoveredAll</th>
			<th>HasDiscoveredHalf</th>
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
	</OrionsBelt:FogOfWarStoragePagedList>
</asp:Content>