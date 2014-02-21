<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignstatus";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search CampaignStatus</h2>
	<p>Use this page to search for objects of the CampaignStatus type.</p>
	<div class="searchTable">
		<OrionsBelt:CampaignStatusSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:CampaignStatusPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>Moves</th>
			<th>Completed</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:CampaignStatusPagedList>
</asp:Content>