<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetresourcestorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlanetResourceStorage</h2>
	<p>Use this page to search for objects of the PlanetResourceStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:PlanetResourceStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlanetResourceStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Quantity</th>
			<th>Level</th>
			<th>Type</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlanetResourceStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlanetResourceStorageId runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageQuantity runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageLevel runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlanetResourceStorageItem>
	</table>
	</OrionsBelt:PlanetResourceStoragePagedList>
</asp:Content>