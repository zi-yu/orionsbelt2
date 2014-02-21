<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetresourcestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlanetResourceStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlanetResourceStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlanetResourceStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlanetResourceStorageQuantitySort InnerHtml="Quantity" runat="server" /></th>
			<th><OrionsBelt:PlanetResourceStorageLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:PlanetResourceStorageTypeSort InnerHtml="Type" runat="server" /></th>
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
	<OrionsBelt:PlanetResourceStorageNumberPagination runat="server" />
	</OrionsBelt:PlanetResourceStoragePagedList>

</asp:Content>