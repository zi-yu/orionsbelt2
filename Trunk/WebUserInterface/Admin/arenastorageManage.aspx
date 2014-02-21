<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenastorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ArenaStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ArenaStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ArenaStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageIsInBattleSort InnerHtml="IsInBattle" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageConquestTickSort InnerHtml="ConquestTick" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageBattleTypeSort InnerHtml="BattleType" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageCoordinateSort InnerHtml="Coordinate" runat="server" /></th>
			<th><OrionsBelt:ArenaStoragePaymentSort InnerHtml="Payment" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ArenaStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ArenaStorageItem runat="server">
		<tr>
			<td><OrionsBelt:ArenaStorageId runat="server" /></td>
			<td><OrionsBelt:ArenaStorageName runat="server" /></td>
			<td><OrionsBelt:ArenaStorageIsInBattle runat="server" /></td>
			<td><OrionsBelt:ArenaStorageConquestTick runat="server" /></td>
			<td><OrionsBelt:ArenaStorageBattleType runat="server" /></td>
			<td><OrionsBelt:ArenaStorageCoordinate runat="server" /></td>
			<td><OrionsBelt:ArenaStoragePayment runat="server" /></td>
			<td><OrionsBelt:ArenaStorageLevel runat="server" /></td>
			<td><OrionsBelt:ArenaStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ArenaStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ArenaStorageItem>
	</table>
	<OrionsBelt:ArenaStorageNumberPagination runat="server" />
	</OrionsBelt:ArenaStoragePagedList>

</asp:Content>