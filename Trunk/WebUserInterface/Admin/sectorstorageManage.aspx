<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "sectorstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:SectorStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:SectorStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:SectorStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:SectorStorageTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:SectorStorageSystemXSort InnerHtml="SystemX" runat="server" /></th>
			<th><OrionsBelt:SectorStorageSystemYSort InnerHtml="SystemY" runat="server" /></th>
			<th><OrionsBelt:SectorStorageSectorXSort InnerHtml="SectorX" runat="server" /></th>
			<th><OrionsBelt:SectorStorageSectorYSort InnerHtml="SectorY" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:SectorStorageItem runat="server">
		<tr>
			<td><OrionsBelt:SectorStorageId runat="server" /></td>
			<td><OrionsBelt:SectorStorageType runat="server" /></td>
			<td><OrionsBelt:SectorStorageSystemX runat="server" /></td>
			<td><OrionsBelt:SectorStorageSystemY runat="server" /></td>
			<td><OrionsBelt:SectorStorageSectorX runat="server" /></td>
			<td><OrionsBelt:SectorStorageSectorY runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:SectorStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:SectorStorageItem>
	</table>
	<OrionsBelt:SectorStorageNumberPagination runat="server" />
	</OrionsBelt:SectorStoragePagedList>

</asp:Content>