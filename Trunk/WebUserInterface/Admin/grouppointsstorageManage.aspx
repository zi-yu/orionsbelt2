<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "grouppointsstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:GroupPointsStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:GroupPointsStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:GroupPointsStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageStageSort InnerHtml="Stage" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStoragePontuationSort InnerHtml="Pontuation" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageWinsSort InnerHtml="Wins" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageLossesSort InnerHtml="Losses" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:GroupPointsStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:GroupPointsStorageNumberPagination runat="server" />
	</OrionsBelt:GroupPointsStoragePagedList>

</asp:Content>