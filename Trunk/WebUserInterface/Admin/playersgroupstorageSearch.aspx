<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playersgroupstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlayersGroupStorage</h2>
	<p>Use this page to search for objects of the PlayersGroupStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:PlayersGroupStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlayersGroupStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>EliminatoryNumber</th>
			<th>PlayersIds</th>
			<th>GroupNumber</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlayersGroupStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayersGroupStorageId runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageEliminatoryNumber runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStoragePlayersIds runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageGroupNumber runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayersGroupStorageItem>
	</table>
	</OrionsBelt:PlayersGroupStoragePagedList>
</asp:Content>