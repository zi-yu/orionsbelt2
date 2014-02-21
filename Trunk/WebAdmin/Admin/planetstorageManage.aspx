<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlanetStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlanetStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlanetStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlanetStorageNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:PlanetStorageProductionFactorSort InnerHtml="ProductionFactor" runat="server" /></th>
			<th><OrionsBelt:PlanetStorageInfoSort InnerHtml="Info" runat="server" /></th>
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
	<OrionsBelt:PlanetStorageNumberPagination runat="server" />
	</OrionsBelt:PlanetStoragePagedList>

</asp:Content>