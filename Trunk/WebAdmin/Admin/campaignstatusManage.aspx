<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignstatus";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:CampaignStatusPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:CampaignStatusNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:CampaignStatusIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusMovesSort InnerHtml="Moves" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusCompletedSort InnerHtml="Completed" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignStatusLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:CampaignStatusItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignStatusId runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLevel runat="server" /></td>
			<td><OrionsBelt:CampaignStatusMoves runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCompleted runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignStatusDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignStatusItem>
	</table>
	<OrionsBelt:CampaignStatusNumberPagination runat="server" />
	</OrionsBelt:CampaignStatusPagedList>

</asp:Content>