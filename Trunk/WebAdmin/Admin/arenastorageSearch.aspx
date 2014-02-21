<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenastorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ArenaStorage</h2>
	<p>Use this page to search for objects of the ArenaStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:ArenaStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ArenaStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>IsInBattle</th>
			<th>ConquestTick</th>
			<th>BattleType</th>
			<th>Coordinate</th>
			<th>Payment</th>
			<th>Level</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ArenaStoragePagedList>
</asp:Content>