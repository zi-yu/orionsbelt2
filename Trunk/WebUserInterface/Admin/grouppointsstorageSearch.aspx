<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "grouppointsstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search GroupPointsStorage</h2>
	<p>Use this page to search for objects of the GroupPointsStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:GroupPointsStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:GroupPointsStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Stage</th>
			<th>Pontuation</th>
			<th>Wins</th>
			<th>Losses</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:GroupPointsStorageItem runat="server">
		<tr>
			<td><OrionsBelt:GroupPointsStorageId runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageStage runat="server" /></td>
			<td><OrionsBelt:GroupPointsStoragePontuation runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageWins runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageLosses runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:GroupPointsStorageItem>
	</table>
	</OrionsBelt:GroupPointsStoragePagedList>
</asp:Content>