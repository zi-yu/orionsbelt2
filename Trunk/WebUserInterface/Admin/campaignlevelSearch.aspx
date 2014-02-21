<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignlevel";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search CampaignLevel</h2>
	<p>Use this page to search for objects of the CampaignLevel type.</p>
	<div class="searchTable">
		<OrionsBelt:CampaignLevelSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:CampaignLevelPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>BotFleet</th>
			<th>PlayerFleet</th>
			<th>Level</th>
			<th>BotName</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:CampaignLevelItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignLevelId runat="server" /></td>
			<td><OrionsBelt:CampaignLevelBotFleet runat="server" /></td>
			<td><OrionsBelt:CampaignLevelPlayerFleet runat="server" /></td>
			<td><OrionsBelt:CampaignLevelLevel runat="server" /></td>
			<td><OrionsBelt:CampaignLevelBotName runat="server" /></td>
			<td><OrionsBelt:CampaignLevelCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLevelUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLevelLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignLevelDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignLevelItem>
	</table>
	</OrionsBelt:CampaignLevelPagedList>
</asp:Content>