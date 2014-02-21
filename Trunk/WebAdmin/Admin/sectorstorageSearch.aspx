<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "sectorstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search SectorStorage</h2>
	<p>Use this page to search for objects of the SectorStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:SectorStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:SectorStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Type</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
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
	</OrionsBelt:SectorStoragePagedList>
</asp:Content>