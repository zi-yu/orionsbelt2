<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playersgroupstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlayersGroupStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlayersGroupStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlayersGroupStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStorageEliminatoryNumberSort InnerHtml="EliminatoryNumber" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStoragePlayersIdsSort InnerHtml="PlayersIds" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStorageGroupNumberSort InnerHtml="GroupNumber" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayersGroupStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:PlayersGroupStorageNumberPagination runat="server" />
	</OrionsBelt:PlayersGroupStoragePagedList>

</asp:Content>