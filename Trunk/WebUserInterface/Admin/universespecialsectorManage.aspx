<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "universespecialsector";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:UniverseSpecialSectorPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:UniverseSpecialSectorNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:UniverseSpecialSectorIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:UniverseSpecialSectorSystemXSort InnerHtml="SystemX" runat="server" /></th>
			<th><OrionsBelt:UniverseSpecialSectorSystemYSort InnerHtml="SystemY" runat="server" /></th>
			<th><OrionsBelt:UniverseSpecialSectorSectorXSort InnerHtml="SectorX" runat="server" /></th>
			<th><OrionsBelt:UniverseSpecialSectorSectorYSort InnerHtml="SectorY" runat="server" /></th>
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
	<OrionsBelt:UniverseSpecialSectorNumberPagination runat="server" />
	</OrionsBelt:UniverseSpecialSectorPagedList>

</asp:Content>