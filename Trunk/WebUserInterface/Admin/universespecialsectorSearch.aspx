<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "universespecialsector";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search UniverseSpecialSector</h2>
	<p>Use this page to search for objects of the UniverseSpecialSector type.</p>
	<div class="searchTable">
		<OrionsBelt:UniverseSpecialSectorSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:UniverseSpecialSectorPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:UniverseSpecialSectorItem runat="server">
		<tr>
			<td><OrionsBelt:UniverseSpecialSectorId runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSystemX runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSystemY runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSectorX runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSectorY runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorDelete runat="server" /></td>
		</tr>
		</OrionsBelt:UniverseSpecialSectorItem>
	</table>
	</OrionsBelt:UniverseSpecialSectorPagedList>
</asp:Content>