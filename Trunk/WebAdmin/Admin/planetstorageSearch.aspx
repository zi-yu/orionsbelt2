<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlanetStorage</h2>
	<p>Use this page to search for objects of the PlanetStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:PlanetStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlanetStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>ProductionFactor</th>
			<th>Info</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlanetStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlanetStorageId runat="server" /></td>
			<td><OrionsBelt:PlanetStorageName runat="server" /></td>
			<td><OrionsBelt:PlanetStorageProductionFactor runat="server" /></td>
			<td><OrionsBelt:PlanetStorageInfo runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlanetStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlanetStorageItem>
	</table>
	</OrionsBelt:PlanetStoragePagedList>
</asp:Content>